using System;
using System.Collections.Generic;

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
        private class ComponentData
        {
            public Component Component;
            public Action Start;
            public Action OnEnable;
            public Action OnDisable;
            public Action Update;
            public Action LateUpdate;
        }

        private readonly List<ComponentData> _components = new List<ComponentData>();

        public Component AddComponent<T>()
            where T : Component
        {
            return AddComponent(typeof (T)) as T;
        }

        private Component AddComponent(Type type)
        {
            AssertNull();

            if (type.BaseType != typeof(Component))
            {
                
            }

            //TODO: instantiate the specified component type
            throw new NotImplementedException();
        }

        public Component GetComponent<T>()
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// run Update on all components
        /// </summary>
        internal void RunComponentUpdates()
        {
            
        }

        /// <summary>
        /// run LateUpdate on all components
        /// </summary>
        internal void RunComponentLateUpdates()
        {
            
        }
    }
}