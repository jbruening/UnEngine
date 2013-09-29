using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
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

        public static void print(object message)
        {
            Debug.Log(message);
        }
    }
}
