#if DEBUG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class Component : Object
    {
        public Transform transform;

        public Rigidbody rigidbody;
        private Camera _camera;

        public Camera camera
        {
            get { AssertNull(); return _camera; }
            private set { _camera = value; }
        }
    }
}
