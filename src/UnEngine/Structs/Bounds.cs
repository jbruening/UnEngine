using System;
#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public struct Bounds
    {
        private Vector3 _center;
        private Vector3 _extents;

        public Vector3 center
        {
            get { return _center; }
            set { _center = value; }
        }

        public Vector3 size
        {
            get { return _extents*2f; }
            set { _extents = value*0.5f; }
        }

        public Vector3 extents
        {
            get { return _extents; }
            set { _extents = value; }
        }

        public Vector3 min
        {
            get { return center - extents; }
            set { SetMinMax(value, max); }
        }

        public Vector3 max
        {
            get { return center + extents; }
            set { SetMinMax(min, value); }
        }

        public Bounds(Vector3 center, Vector3 size)
        {
            _center = center;
            _extents = size * 0.5f;
        }

        public static bool operator ==(Bounds lhs, Bounds rhs)
        {
            if (lhs.center == rhs.center)
                return lhs.extents == rhs.extents;
            return false;
        }

        public static bool operator !=(Bounds lhs, Bounds rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return center.GetHashCode() ^ extents.GetHashCode() << 2;
        }

        public override bool Equals(object other)
        {
            if (!(other is Bounds))
                return false;
            var bounds = (Bounds)other;
            return center.Equals((object) bounds.center) && extents.Equals((object)bounds.extents);
        }

        public void SetMinMax(Vector3 min, Vector3 max)
        {
            extents = (max - min) * 0.5f;
            center = min + extents;
        }

        public void Encapsulate(Vector3 point)
        {
            SetMinMax(Vector3.Min(min, point), Vector3.Max(max, point));
        }

        public void Encapsulate(Bounds bounds)
        {
            Encapsulate(bounds.center - bounds.extents);
            Encapsulate(bounds.center + bounds.extents);
        }

        public void Expand(float amount)
        {
            amount *= 0.5f;
            extents += new Vector3(amount, amount, amount);
        }

        public void Expand(Vector3 amount)
        {
            extents += amount * 0.5f;
        }

        public bool Intersects(Bounds bounds)
        {
            if (min.x <= (double)bounds.max.x && 
                max.x >= (double)bounds.min.x && 
                (min.y <= (double)bounds.max.y && 
                max.y >= (double)bounds.min.y) && 
                min.z <= (double)bounds.max.z)
                return max.z >= (double)bounds.min.z;
            
            return false;
        }

        public bool Contains(Vector3 point)
        {
            throw new NotImplementedException();
        }

        public float SqrDistance(Vector3 point)
        {
            throw new NotImplementedException();
        }

        public bool IntersectRay(Ray ray)
        {
            throw new NotImplementedException();
        }

        public bool IntersectRay(Ray ray, out float distance)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("Center: {0}, Extents: {1}", _center, _extents);
        }

        public string ToString(string format)
        {
            return string.Format("Center: {0}, Extents: {1}", _center.ToString(format), _extents.ToString(format));
        }
    }
}