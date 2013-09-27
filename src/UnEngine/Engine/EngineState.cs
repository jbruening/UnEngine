using System.Diagnostics;

namespace UnityEngine.Engine
{
    /// <summary>
    /// used to do various engine things, such as update, lateupdate, etc
    /// </summary>
    public sealed class EngineState
    {
        readonly Stopwatch _watch = new Stopwatch();
        
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
        /// <summary>
        /// run a single step
        /// </summary>
        public void Update()
        {
            Time.Update((float) _watch.Elapsed.TotalSeconds);
            //TODO: call update on everything
            //TODO: call lateupdate on everything
        }
    }
}
