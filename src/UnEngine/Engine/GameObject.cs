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
    public class GameObject : Object
    {
        public Component AddComponent<T>()
        {
            throw new NotImplementedException();
        }

        public Component GetComponent<T>()
        {
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