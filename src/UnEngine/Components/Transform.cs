using System;
using System.Collections.Generic;

#if DEBUG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public sealed class Transform : Component
    {
        private Transform(){}
        private Vector3 _position;
        private Quaternion _rotation;
        private Transform _parent;

        private List<Transform> _children;

        private Vector3 _localScale;
        private Vector3 _localPosition;
        private Quaternion _localRotation;

        //TODO: use local coordinates, and multiply matrices and walk the heirarchy to determine absolute position/rotation
        public Vector3 position
        {
            get
            {
                AssertNull();
                return _position;
            }
            set
            {
                AssertNull();
                _position = value;
            }
        }
        public Quaternion rotation
        {
            get
            {
                AssertNull();
                return _rotation;
            }
            set
            {
                AssertNull();
                _rotation = value;
            }
        }
        public Vector3 localScale
        {
            get
            {
                AssertNull();
                return _localScale;
            }
            set
            {
                AssertNull();
                _localScale = value;
            }
        }
        public Vector3 localPosition
        {
            get
            {
                AssertNull();
                return _localPosition;
            }
            set
            {
                AssertNull();
                _localPosition = value;
            }
        }

        public Quaternion localRotation
        {
            get
            {
                AssertNull();
                return _localRotation;
            }
            set
            {
                AssertNull();
                _localRotation = value;
            }
        }

        public Transform parent
        {
            get
            {
                AssertNullRef(ref _parent);
                return _parent;
            }
            set
            {
                AssertNull();
                _parent = value;
            }
        }

        public Transform root
        {
            get
            {
                AssertNull();

                //go up parents until null
                Transform cParent = _parent;
                while (!IsNull(cParent))
                {
                    //don't use parent property, otherwise we might throw an error just traversing
                    cParent = cParent._parent;
                }
                return cParent;
            }
        }

        public Matrix4x4 worldToLocalMatrix
        {
            get
            {
                AssertNull();
                Matrix4x4 matrix4x4;
                throw new NotImplementedException();
                return matrix4x4;
            }
        }

        public Vector3 right
        {
            get { return rotation*Vector3.right; }
            set { rotation = Quaternion.FromToRotation(Vector3.right, value); }
        }
        public Vector3 up
        {
            get { return rotation*Vector3.up; }
            set { rotation = Quaternion.FromToRotation(Vector3.up, value); }
        }
        public Vector3 forward
        {
            get { return rotation*Vector3.forward; }
            set { rotation = Quaternion.LookRotation(value); }
        }

        public void Translate(Vector3 translation)
        {
          Space relativeTo = Space.Self;
          this.Translate(translation, relativeTo);
        }

        public void Translate(Vector3 translation, Space relativeTo)
        {
            if (relativeTo == Space.World)
                position += translation;
            else
                position += this.TransformDirection(translation);
        }

        public void Translate(float x, float y, float z)
        {
            const Space relativeTo = Space.Self;
            Translate(x, y, z, relativeTo);
        }

        public void Translate(float x, float y, float z, Space relativeTo)
        {
            Translate(new Vector3(x, y, z), relativeTo);
        }

        public void Translate(Vector3 translation, Transform relativeTo)
        {
            if ((bool) ((Object) relativeTo))
                position += relativeTo.TransformDirection(translation);
            else
                position += translation;
        }

        public void Translate(float x, float y, float z, Transform relativeTo)
        {
          this.Translate(new Vector3(x, y, z), relativeTo);
        }

        public void Rotate(Vector3 eulerAngles)
        {
          Space relativeTo = Space.Self;
          this.Rotate(eulerAngles, relativeTo);
        }

        public void Rotate(Vector3 eulerAngles, Space relativeTo)
        {
            var quaternion = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
            if (relativeTo == Space.Self)
                this.localRotation = this.localRotation * quaternion;
            else
                rotation = this.rotation * Quaternion.Inverse(this.rotation) * quaternion * this.rotation;
        }

        public void Rotate(float xAngle, float yAngle, float zAngle)
        {
            const Space relativeTo = Space.Self;
            Rotate(xAngle, yAngle, zAngle, relativeTo);
        }

        public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo)
        {
            Rotate(new Vector3(xAngle, yAngle, zAngle), relativeTo);
        }

        public void Rotate(Vector3 axis, float angle)
        {
            const Space relativeTo = Space.Self;
            Rotate(axis, angle, relativeTo);
        }

        public void Rotate(Vector3 axis, float angle, Space relativeTo)
        {
            throw new NotImplementedException();
        }

        public void RotateAround(Vector3 point, Vector3 axis, float angle)
        {
            throw new NotImplementedException();
        }

        public Vector3 TransformDirection(Vector3 direction)
        {
            throw new NotImplementedException();
        }
    }
}