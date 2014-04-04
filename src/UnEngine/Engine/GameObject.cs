using System;
using System.Collections.Generic;
using System.Reflection;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public class GameObject : Object
    {
		public bool activeInHierarchy { get; set; }

        private readonly List<Component> _components = new List<Component>();

        public GameObject()
        {
            name = "";
            SetupGameObject(this);
        }
        public GameObject(string name)
        {
            this.name = name;
            SetupGameObject(this);
        }
        public GameObject(string name, params Type[] components)
        {
            this.name = name;
            SetupGameObject(this);
            foreach (var t in components)
            {
                AddComponent(t);
            }
        }

        internal static void SetupGameObject(GameObject gobj, bool isRuntime = true)
        {
            if (isRuntime)
            {
                gobj.IsPrefab = false;
                gobj.AddComponent(typeof (Transform));
            }
            else
            {
                gobj.IsPrefab = true;
            }

            UnEngine.InternalEngine.EngineState.Instance.Add(gobj);
        }

        public Component AddComponent<T>()
            where T : Component
        {
            return AddComponent(typeof (T)) as T;
        }

        public Component AddComponent(Type type)
        {
            AssertNull();
            
            var component = Activator.CreateInstance(type, true) as Component;

            if (component == null)
            {
                throw new ArgumentException("type needs to be a Component");
            }

            component.IsPrefab = false;
            _AddComponentInstance (component);

            return component;
        }

        public T GetComponent<T>()
            where T : Component
        {
            return GetComponent(typeof (T)) as T;
        }
        public Component GetComponent(string type)
        {
            return GetComponent(Type.GetType(type));
        }
        public Component GetComponent(Type type)
        {
            AssertNull();

            Component pRet = null;
            while (!pRet)
            {
                var ind = _components.FindIndex(c => c.GetType() == type);
                if (ind == -1)
                    return null;
                pRet = _components[ind];
                
                //got our component
                if (pRet)
                {
                    return pRet;
                }
                
                //the component is supposed to be destroyed in some capacity. remove it.
                _components.RemoveAt(ind);
                pRet = null;
            }
            return pRet;
        }

		public T[] GetComponents<T>()
			where T : Component
		{
			return GetComponents(typeof(T)) as T[];
		}
		public Component[] GetComponents(string type)
		{
			return GetComponents(Type.GetType(type));
		}
		public Component[] GetComponents(Type type)
		{
			AssertNull();
			
			var pRet = _components.FindAll(c => c.GetType() == type);

			return pRet.ToArray();
		}

        /// <summary>
        /// remove the exact component
        /// </summary>
        /// <param name="component"></param>
        internal void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public T GetComponentInChildren<T>() where T : Component
        {
            return (T)GetComponentInChildren(typeof(T));
        }
        public Component GetComponentInChildren(Type type)
        {
            AssertNull();
            //TODO: recursively walk heirarchy
            throw new NotImplementedException();
        }

        public T[] GetComponentsInChildren<T>(bool includeInactive = false) where T : Component
        {
            return GetComponentsInChildren(typeof(T), includeInactive) as T[];
        }

        public Component[] GetComponentsInChildren(Type t, bool includeInactive = false)
        {
            AssertNull();
            throw new NotImplementedException();
        }

        public void SetActive(bool value)
        {
            AssertNull();
            throw new NotImplementedException();
        }

        public bool CompareTag(string tag)
        {
            AssertNull();
            throw new NotImplementedException();
        }

        public void SendMessageUpwards(string methodName, object value = null, SendMessageOptions options = SendMessageOptions.RequireReceiver)
        {
            AssertNull();
            //TODO: walk up heiarchy, doing sendmessage on each gameobject
            throw new NotImplementedException();
        }

        /// <summary>
        /// Run the specified method name on all components on this gameobject
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="value"></param>
        /// <param name="options">if requirereceiver, and no methods were run, throw an error</param>
        public void SendMessage(string methodName, object value = null,
                                SendMessageOptions options = SendMessageOptions.RequireReceiver)
        {
            AssertNull();
            throw new NotImplementedException();
        }

        public void BroadcastMessage(string methodName, object parameter = null,
                                     SendMessageOptions options = SendMessageOptions.RequireReceiver)
        {
            AssertNull();
            throw new NotImplementedException();
        }

        public void SampleAnimation(AnimationClip animation, float time)
        {
            AssertNull();
            throw new NotImplementedException();
        }

        /// <summary>
        /// run Update on all components
        /// </summary>
        internal void RunComponentUpdates()
        {
            foreach (var component in _components)
            {
                component.DoUpdate();
            }
        }

		internal void RunCoroutines()
		{
			foreach (var component in _components)
			{
				MonoBehaviour monoBehaviour = component as MonoBehaviour;
				if (monoBehaviour)
				{
					monoBehaviour.UpdateCoroutines();
				}
			}
		}

        /// <summary>
        /// run LateUpdate on all components
        /// </summary>
        internal void RunComponentLateUpdates()
        {
            foreach (var comp in _components)
            {
                comp.DoLateUpdate();
            }
        }

		internal void RunEndOfFrameCoroutines()
		{
			foreach (var component in _components)
			{
				MonoBehaviour monoBehaviour = component as MonoBehaviour;
				if(monoBehaviour)
				{
					monoBehaviour.UpdateEndOfFrameCoroutines();
				}
			}
		}

        public static GameObject FindWithTag(string tag)
        {
            return FindGameObjectWithTag(tag);
        }

        public static GameObject FindGameObjectWithTag(string tag)
        {
            throw new NotImplementedException();
        }

        public static GameObject[] FindGameObjectsWithTag(string tag)
        {
            throw new NotImplementedException();
        }

        public Transform transform { get { return GetComponent<Transform>(); } }
        public Rigidbody rigidbody { get { return GetComponent<Rigidbody>(); } }
        public Light light { get { return GetComponent<Light>(); } }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public List<Component> _GetAllComponents ()
        {
            return _components;
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public void _AddComponentInstance (Component component)
        {
            component.gameObject = this;
            _components.Add (component);

            try
            {
                component.DoAwake ();
            }
            catch (Exception e)
            {
                Debug.LogException (e, this);
            }
        }
    }
}