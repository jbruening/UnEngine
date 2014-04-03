using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public class MonoBehaviour : Component
    {
        private bool _useGUILayout = true;
        public bool useGUILayout
        {
            get
            {
                AssertNull();
                return _useGUILayout;
            }
            set
            {
                AssertNull();
                _useGUILayout = value;
            }
        }

		private List<Coroutine> _coroutines = new List<Coroutine>();
		private List<Coroutine> _endOfFrameCoroutines = new List<Coroutine>();

        private Action _awake;
        private Action _start;
        private Action _update;
        private Action _lateUpdate;
        private Action _fixedUpdate;
        private Action _onDisable;
        private Action _onDestroy;
        private Action _onEnable;
        private Action _onGUI;
        private Action<int> _onLevelWasLoaded;

        public void CancelInvoke(string methodName)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public void CancelInvoke()
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public void Invoke(string methodName, float time)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public void InvokeRepeating(string methodName, float time, float repeatRate)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public bool IsInvoking()
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public bool IsInvoking(string methodName)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public Coroutine StartCoroutine(string methodName)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public Coroutine StartCoroutine(string methodName, object value)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public Coroutine StartCoroutine(IEnumerator routine)
        {
            AssertNull();

			try
			{
				var coroutine = new Coroutine(routine);
				ScheduleCoroutine(coroutine);
				return coroutine;
			}
			catch (InvalidOperationException)
			{
				return null;
			}
        }

		internal void ScheduleCoroutine(Coroutine coroutine)
		{
			if (coroutine.Enumerator.Current is WaitForEndOfFrame)
			{
				_endOfFrameCoroutines.Add(coroutine);
			}
			else
			{
				_coroutines.Add(coroutine);
			}
		}

        public Coroutine StartCoroutine_Auto(IEnumerator routine)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public void StopAllCoroutines()
        {
            AssertNull();
            throw new NotImplementedException();
        }
        public void StopCoroutine(string methodName)
        {
            AssertNull();
            throw new NotImplementedException();
        }
        
        protected override void CStart()
        {
            if (_start != null)
                _start();
        }

		internal void UpdateCoroutines()
		{
			var tempList = new List<Coroutine>(_coroutines);
			_coroutines.Clear();
			foreach (var coroutine in tempList)
			{
				coroutine.Run();
				if(coroutine.isDone)
				{
					ScheduleCoroutine(coroutine);
				}
			}
		}

		internal void UpdateEndOfFrameCoroutines()
		{
			var tempList = new List<Coroutine>(_endOfFrameCoroutines);
			_endOfFrameCoroutines.Clear();
			foreach (var coroutine in tempList)
			{
				coroutine.Run();
				if (coroutine.isDone)
				{
					ScheduleCoroutine(coroutine);
				}
			}
		}

        protected override void CUpdate()
        {
            if (_update != null)
                _update();
        }

        protected override void CLateUpdate()
        {
            if (_lateUpdate != null)
                _lateUpdate();
        }

        protected override void CAwake()
        {
            //Get all the methods that monobehaviour can 'override'
            var methods = GetMethods(
                this,
                new List<string>()
                    {
                        "Awake",
                        "Start", 
                        "Update",
                        "LateUpdate",
                    },
                new List<Type>()
                    {
                        typeof(Action),
                        typeof(Action),
                        typeof(Action),
                        typeof(Action),
                    });

            _awake = methods[0] as Action;
            _start = methods[1] as Action;
            _update = methods[2] as Action;
            _lateUpdate = methods[3] as Action;

            if (_awake != null)
                _awake();
        }
        
        private object[] GetMethods(object target, List<string> methodNames, List<Type> methodTypes)
        {
            if (methodNames.Count != methodTypes.Count)
                throw new ArgumentOutOfRangeException("methodTypes", "methodNames and methodTypes must be the same length");

            MethodInfo[] methods = target.GetType().GetMethods(
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.FlattenHierarchy);

            object[] retMethods = new object[methodNames.Count];

            foreach (var method in methods)
            {
                var ind = methodNames.IndexOf(method.Name);
                if (ind != -1)
                {
                    retMethods[ind] = Delegate.CreateDelegate(methodTypes[ind], target, method, false);
                }
            }

            return retMethods;
        }

        public static void print(object message)
        {
            Debug.Log(message);
        }
    }
}
