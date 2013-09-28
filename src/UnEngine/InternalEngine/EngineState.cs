using System;
using System.Collections.Generic;
#if !DEBUG
using UnityEngine;
#endif

namespace UnEngine.InternalEngine
{
    /// <summary>
    /// used to do various engine things, such as update, lateupdate, etc
    /// </summary>
    public sealed class EngineState
    {
        private readonly System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
        private readonly Dictionary<int, GameObject> _gameObjects = new Dictionary<int, GameObject>();
        
        private static EngineState _instance;
        internal static EngineState Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EngineState();
                    _instance.Setup();
                }

                return _instance;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Setup()
        {
            Time.Update(0);
        }

        readonly List<int> _keysToRemove = new List<int>();
        /// <summary>
        /// run a single step
        /// </summary>
        public void Update()
        {
            Time.Update((float) _watch.Elapsed.TotalSeconds);
            
            
            //TODO: call update on everything
            _keysToRemove.Clear();
            foreach (var kvp in _gameObjects)
            {
                if (Object.IsNull(kvp.Value))
                {
                    _keysToRemove.Add(kvp.Key);
                }
                else
                {
                    try
                    {
                        kvp.Value.RunComponentUpdates();
                    }
                    catch (Exception e)
                    {
                        Debug.Exception(e);
                    }
                }
            }

            //clear out destroyed objects
            foreach (var key in _keysToRemove)
            {
                _gameObjects.Remove(key);
            }
            _keysToRemove.Clear();

            //TODO: call lateupdate on everything
        }
    }
}