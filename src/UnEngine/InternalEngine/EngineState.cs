using System;
using System.Collections.Generic;
using System.Linq;

#if !UNENG
using UnityEngine;
using Object = UnityEngine.Object;

#endif

namespace UnEngine.InternalEngine
{
    /// <summary>
    /// used to do various engine things, such as update, lateupdate, etc
    /// </summary>
    public sealed class EngineState
    {
        private readonly System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
        private readonly IntDictionary<GameObject> _gameObjects = new IntDictionary<GameObject>();
        
        private static EngineState _instance;
        public static EngineState Instance
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
        public void Update(float? newTime = null)
        {
            if (newTime == null)
                Time.Update((float) _watch.Elapsed.TotalSeconds);
            else
                Time.Update(newTime.Value);
            
            
            //TODO: call update on everything
            _keysToRemove.Clear();

            for (int i = 0; i < _gameObjects.Capacity; i++)
            {
                GameObject gobj;
                if (_gameObjects.TryGetValue(i, out gobj))
                {
                    if (Object.IsNull(gobj))
                    {
                        _gameObjects.Remove(i);
                    }
                    else
                    {
                        gobj.RunComponentUpdates();
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

        internal void Add(GameObject gobj)
        {
            var id = _gameObjects.Add(gobj);
            gobj.ReferenceData = new ReferenceData {InstanceID = id};
        }
    }
}