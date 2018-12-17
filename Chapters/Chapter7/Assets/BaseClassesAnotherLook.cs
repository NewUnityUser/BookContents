﻿/*
 * Chapter 7.6 Base Classes: Another Look
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
namespace Chapter7_6_1
{
    using System;
    using System.Collections;
    using UnityEngine;
    /*
     * Section 7.6.1 Generalization -- Base Classes
     */
    public abstract class BaseClass
    {
        #region BaseProperties
        private float _speed;
        protected float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        private float _turn;
        protected float Turn
        {
            get { return _turn; }
            set { _turn = value; }
        }
        private Vector3 _position;
        protected Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private MeshFilter _meshFilter;
        protected MeshFilter MeshFilter
        {
            get { return _meshFilter; }
            set { _meshFilter = value; }
        }
        private Material _material;
        protected Material Material
        {
            get { return _material; }
            set { _material = value; }
        }
        #endregion
        #region BaseFunctions
        public abstract void Initialize(MeshFilter meshFilter, Material material);
        public abstract void MoveForward(float speed, float turn);
        public abstract void UpdateChild();

        public virtual void Speak()
        {
            Debug.Log("Base Hello.");
        }
        #endregion
    }

    /*
     * Section 7.6.2 Specialization
     */
    public class ChildA : BaseClass
    {
        #region ChildA_Properties
        protected GameObject Me;
        protected Mesh Mesh;
        protected MeshRenderer MeshRenderer;

        #endregion
        public override void Initialize(MeshFilter meshFilter, Material material)
        {
            Me = new GameObject(this.ToString());
            MeshFilter = Me.AddComponent<MeshFilter>();
            Mesh = meshFilter.sharedMesh;
            MeshFilter.sharedMesh = Mesh;
            Material = material;
            MeshRenderer = Me.AddComponent<MeshRenderer>();
            MeshRenderer.material = Material;
        }

        public override void MoveForward(float speed, float turn)
        {
            Speed += speed;
            Turn += turn;
            Position += Me.transform.forward * speed;
            Me.transform.position = Position;
        }
        public override void Speak()
        {
            base.Speak();
        }
        public override void UpdateChild()
        {
            Me.transform.position = Position;
            Me.transform.eulerAngles = new Vector3(0, Turn, 0);
        }
    }

    /*
     * Section 7.6.3 Base
     */
    public class ChildB : ChildA
    {
        #region ChildB_properties
        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion


        public override void Initialize(MeshFilter meshFilter, Material material)
        {
            /* the base keyword here does the work from   *
             * the parent class this class inherits from. */
            base.Initialize(meshFilter, material);
            //New for ChildB
            Color = new Color(1, 0, 0, 1);
            MeshRenderer.material.color = Color;
        }
    }

    public class ManageChildren : MonoBehaviour
    {
        public MeshFilter ChildMesh;
        public Material ChildMaterial;
        BaseClass[] children;
        BaseClass FirstChild;
        BaseClass SecondChild;
        public void Initialize()
        {
            children = new BaseClass[2];
            children[0] = new ChildA();
            children[0].Initialize(ChildMesh, ChildMaterial);
            children[1] = new ChildB();
            children[1].Initialize(ChildMesh, ChildMaterial);
        }
        //Update is called once per frame
        private void Update()
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].MoveForward(i * 0.1f + 0.1f, i * 1.5f + 3.0f);
                children[i].UpdateChild();
                children[i].Speak();
            }

            if (FirstChild != null)
            {
                FirstChild.MoveForward(0.1f, 3.0f);
                FirstChild.UpdateChild();
                FirstChild.Speak();
            }

            if (SecondChild != null)
            {
                SecondChild.MoveForward(0.05f, -3.0f);
                SecondChild.UpdateChild();
                SecondChild.Speak();
            }

        }
    }

    public class BaseClassesAnotherLook : MonoBehaviour
    {
        public MeshFilter ChildMesh;
        public Material ChildMaterial;
        private void Start()
        {
            ManageChildren manager = gameObject.AddComponent<ManageChildren>();
            manager.ChildMesh = ChildMesh;
            manager.ChildMaterial = ChildMaterial;
            manager.Initialize();
        }
    }

    /*
     * Section 7.6.4 Partial
     */
    // ChildCProperties.cs
    public partial class ChildC : ChildA
    {
        private float _scale;
        protected float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
    }

    // ChildCFunctions.cs
    public partial class ChildC : ChildA
    {
        protected void SetScale(float scale)
        {
            Scale = scale;
            Me.transform.localScale = Vector3.one * Scale;
        }
        public override void Initialize(MeshFilter meshFilter, Material material)
        {
            base.Initialize(meshFilter, material);
            SetScale(2.0f);
        }
    }

    /*
     * Section 7.6.4 Partial Continued.
     */
    // ShapeProperties.cs
    public abstract partial class BaseShape
    {
        public enum Shapes                    /* * * * * * * * * * * */
        {                                     /* this class could    */
            Cube,                             /* implement variables */
            Sphere                            /* properties, and     */
        };                                    /* store declarations  */
        Shapes Shape;                         /* for use elsewhere   */
    }                                         /* * * * * * * * * * * */

    // ShapeFunctions.cs
    public abstract partial class BaseShape           /* * * * * * * * */
    {                                                 /* here we could */
        public abstract void SetShape(Shapes shape);  /* implement the */
    }                                                 /* functions for */
                                                      /* the class as  */
    public class SomeShape : BaseShape                /* necessary.    */
    {                                                 /* * * * * * * * */
        public GameObject Me;
        public override void SetShape(Shapes shape)
        {
            switch (shape)
            {
                case Shapes.Cube:
                    Me = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
                case Shapes.Sphere:
                    Me = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
            }
        }

        /* * * * * * * * * * * * * * * * * * * * * * */
        /* Adding in these to avoid errors in Unity  */
        /* * * * * * * * * * * * * * * * * * * * * * */
        public override void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public override int Count => throw new NotImplementedException();

        public override bool IsSynchronized => throw new NotImplementedException();

        public override object SyncRoot => throw new NotImplementedException();

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override object Current => throw new NotImplementedException();
    }

    /*
     * Section 7.6.4 Partial Continued.
     */
        // ShapeICollection.cs
        public abstract partial class BaseShape : System.Collections.ICollection
    {
        public abstract void CopyTo(Array array, int index);

        public abstract int Count { get; }
        public abstract bool IsSynchronized { get; }
        public abstract object SyncRoot { get; }

        public abstract IEnumerator GetEnumerator();
    }

    //ShapeIEnumerator.cs
    public abstract partial class BaseShape : System.Collections.IEnumerator
    {
        public abstract bool MoveNext();
        public abstract void Reset();

        public abstract object Current { get; }
    }

    /*
     * Section 7.6.5 Protected Private and Public
     */
    class ProtectedPrivateAndPublic
    {
        /* for any class : System.Object is     */
        /* assumed to be a base class for       */
        /* any class not declaring anything     */
        class Base : System.Object
        {
            private string MyPrivateString;
            protected string MyProtectedString;
            public string MyPublicString;
        }
        /* A child of base cannot see the       */
        /* private string.                      */
        class Child : Base
        {
            void VisibleProperties()
            {
                MyProtectedString = "";
                MyPublicString = "";
            }
        }

        partial class Half : System.Object
        {
            private string MyPrivateString;
        }

        partial class Half : System.Object
        {
            void SeesPrivates()
            {
                MyPrivateString = "";
            }
        }


    }
}
