using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class Object
    {
        private bool _isNull = true;
        internal bool IsPrefab = false;

        internal ReferenceData ReferenceData;
        private string _name;
        private HideFlags _hideFlags;

        public string name
        {
            get { AssertNull(); return _name; }
            set { AssertNull(); _name = value; }
        }

        public HideFlags hideFlags
        {
            get { AssertNull(); return _hideFlags; }
            set { AssertNull(); _hideFlags = value; }
        }

        public int GetInstanceID()
        {
            AssertNull();
            return ReferenceData.InstanceID;
        }

        public override int GetHashCode()
        {
            return GetInstanceID();
        }

        /// <summary>
        /// throw argumentexception if arg is null, with the specified message
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="message"></param>
        internal static void CheckNullArgument(Object arg, string message)
        {
            if ( arg== null)
                throw new ArgumentException(message);
        }

        /// <summary>
        /// true if the specified object is actually null or is supposed to be null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static bool IsNull(Object obj)
        {
            return obj == null || obj._isNull;
        }

        /// <summary>
        /// throw an error if this object should be null -
        /// replacement for unity's null setting abilities
        /// </summary>
        internal void AssertNull()
        {
            if (_isNull)
                throw new NullReferenceException();
        }
        
        /// <summary>
        /// If obj is supposed to be null, set it to null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>true, if the object was made null/already was null</returns>
        internal bool AssertReference<T>(ref T obj) where T : Object
        {
            if (obj == null) return true;
            if (obj._isNull)
            {
                obj = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// combined AssertReference and AssertNull
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        internal void AssertNullRef<T>(ref T obj) where T : Object
        {
            if (_isNull)
            {
                obj = null;
            }
            throw new NullReferenceException();
        }

        /// <summary>
        /// true if the object actually exists/isn't null
        /// </summary>
        /// <param name="exists"></param>
        /// <returns></returns>
        public static implicit operator bool(Object exists)
        {
            return !ActuallyEquals(exists, null);
        }

        public static bool operator ==(Object x, Object y)
        {
            return ActuallyEquals(x, y);
        }

        public static bool operator !=(Object x, Object y)
        {
            return !ActuallyEquals(x, y);
        }

        public override bool Equals(object o)
        {
            AssertNull();

            return ActuallyEquals(this, (Object)o);
        }

        static bool ActuallyEquals(Object lhs, Object rhs)
        {
            bool lhsIsNull = IsNull(lhs);
            bool rhsIsNull = IsNull(rhs);

            //both are 'null', so they're the same thing
            if (lhsIsNull && rhsIsNull) return true;
            //lhs is null, rhs isn't
            if (lhsIsNull) return false;
            //lhs isn't null, rhs is
            if (rhsIsNull) return false;

            return ReferenceEquals(lhs, rhs);
        }

        /// <summary>
        /// Instantiate the specified object
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Object Instantiate(Object original)
        {
            CheckNullArgument(original, "The thing you want to instantiate is null.");
            //todo: can the object be instantiated in space?
            throw new NotImplementedException();
        }

        /// <summary>
        /// Instantiate the specified object that the specified location and rotation
        /// </summary>
        /// <param name="original"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation)
        {
            //TODO: check if the object is a prefab or an already existing object.
            //then either clone or instantiate
            throw new NotImplementedException();
        }

        /// <summary>
        /// destroy the object at the end of the frame
        /// </summary>
        /// <param name="obj"></param>
        public static void DestroyObject(Object obj)
        {
            const float t = 0f;
            DestroyObject(obj, t);
        }

        public static void DestroyImmediate(Object obj, bool allowDestroyingAssets)
        {
            obj._isNull = true;
        }

        public static void DestroyImmediate(Object obj)
        {
            const bool allowDestroyingAssets = false;
            DestroyImmediate(obj, allowDestroyingAssets);
        }

        /// <summary>
        /// destroy the object after the specified amount of time
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        public static void DestroyObject(Object obj, float t)
        {
            //TODO: set isnull to true once destroyed
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            AssertNull();

            return string.Format("Object {0} : {1}", _name, GetType());
        }
    }
}
