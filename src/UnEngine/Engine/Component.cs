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
    public class Component : Object
    {
        public GameObject gameObject { get; internal set; }

        internal Component()
        {
            
        }

        public Transform transform
        {
            get { return GetComponent<Transform>(); }
        }

        public Rigidbody rigidbody
        {
            get { return GetComponent<Rigidbody>(); }
        }
        
        public Camera camera
        {
            get { return GetComponent<Camera>(); }
        }

        public Light light
        {
            get { return GetComponent<Light>(); }
        }

        public Animation animation
        {
            get { return GetComponent<Animation>(); }
        }

        public ConstantForce constantForce
        {
            get { return GetComponent<ConstantForce>(); }
        }

        protected virtual void CUpdate(){}
        protected virtual void CLateUpdate(){}
        protected virtual void CAwake(){}
        protected virtual void CStart(){}

        internal void DoAwake()
        {
            try
            {
                CAwake();
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }
        }

        internal void DoStart()
        {
            try
            {
                CStart();
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }
        }
        internal void DoUpdate()
        {
            try
            {
                CUpdate();
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }
        }
        internal void DoLateUpdate()
        {
            try
            {
                CLateUpdate();
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }
        }

        public T GetComponent<T>()
            where T : Component
        {
            return GetComponent(typeof (T)) as T;
        }
        public Component GetComponent(Type type)
        {
            AssertNull();
            return gameObject.GetComponent(type);
        }
        public Component GetComponent(string type)
        {
            AssertNull();
            return gameObject.GetComponent(type);
        }

        public T GetComponentInChildren<T>() where T : Component
        {
            return GetComponentInChildren(typeof (T)) as T;
        }

        private Component GetComponentInChildren(Type type)
        {
            AssertNull();
            return gameObject.GetComponentInChildren(type);
        }

        public void SendMessageUpwards(string methodName, object value = null,
                                       SendMessageOptions options = SendMessageOptions.RequireReceiver)
        {
            AssertNull();
            gameObject.SendMessageUpwards(methodName, value, options);
        }

        public void SendMessage(string methodName, object value = null,
                                SendMessageOptions options = SendMessageOptions.RequireReceiver)
        {
            AssertNull();
            gameObject.SendMessage(methodName, value, options);
        }

        public void BroadcastMessage(string methodName, object value = null,
                                     SendMessageOptions options = SendMessageOptions.RequireReceiver)
        {
            AssertNull();
            gameObject.BroadcastMessage(methodName, value, options);
        }
    }
}
