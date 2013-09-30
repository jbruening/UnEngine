#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public struct Ray
    {
        private Vector3 _origin;
        private Vector3 _direction;

        public Vector3 origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector3 direction
        {
            get { return _direction; }
            set { _direction = value.normalized; }
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            _origin = origin;
            _direction = direction.normalized;
        }

        public Vector3 GetPoint(float distance)
        {
            return _origin + _direction * distance;
        }

        public override string ToString()
        {
            return string.Format("Origin: {0}, Dir: {1}", _origin, _direction);
        }

        public string ToString(string format)
        {
            return string.Format("Origin: {0}, Dir: {1}", _origin.ToString(format), _direction.ToString(format));
        }
    }
}