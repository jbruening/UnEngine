using System.Collections;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public sealed class Coroutine : YieldInstruction
    {
		internal bool isDone { get; private set;}
		internal IEnumerator Enumerator { get; private set; }
		internal Coroutine(IEnumerator routine)
		{
			Enumerator = routine;
		}

		internal bool CanRun
		{
			get
			{
				object current = Enumerator.Current;

				if (current is Coroutine)
				{
					Coroutine dep = current as Coroutine;
					return dep.isDone;
				}
				else if (current is WaitForSeconds)
				{
					WaitForSeconds wait = current as WaitForSeconds;
					return wait.Duration <= Time.time;
				}
				else
				{
					return true;
				}
			}
		}

		internal void Run()
		{
			if(CanRun)
			{
				isDone = !Enumerator.MoveNext();
			}
		}
    }
}