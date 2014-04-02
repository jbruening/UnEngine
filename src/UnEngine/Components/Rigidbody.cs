#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public class Rigidbody : Component
    {
		public Vector3 velocity { get; set; }
		public Vector3 angularVelocity { get; set; }
    }
}