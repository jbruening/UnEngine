using System;

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
        public GameObject gameObject { get; internal set; }

        public Transform transform
        {
            get { return GetComponent<Transform>() as Transform; }
        }

        public Rigidbody rigidbody
        {
            get { return GetComponent<Rigidbody>() as Rigidbody; }
        }
        
        public Camera camera
        {
            get { return GetComponent<Camera>() as Camera; }
        }

        public Component GetComponent<T>()
            where T : Component
        {
            return GetComponent(typeof (T)) as T;
        }
        public Component GetComponent(Type type)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public Component GetComponent(string type)
        {
            AssertNull();
            return gameObject.GetComponent(type);
        }
    }
}
