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
    public struct Vector3
    {
        /// <summary>
        /// 
        /// </summary>
        public const float kEpsilon = 1E-05f;
        /// <summary>
        /// 
        /// </summary>
        public float x;
        /// <summary>
        /// 
        /// </summary>
        public float y;
        /// <summary>
        /// s
        /// </summary>
        public float z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        /// <summary>
        /// get a vector3 in the same direction as this, but with a magnitude of 1
        /// </summary>
        public Vector3 normalized
        {
            get { return Normalize(this); }
        }

        /// <summary>
        /// get the length of this vector3
        /// slow. requires a square root
        /// </summary>
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * (double)x + y * (double)y + z * (double)z);
            }
        }

        /// <summary>
        /// get the squared length of this vector3
        /// </summary>
        public float sqrMagnitude
        {
            get { return (float) (x*(double) x + y*(double) y + z*(double) z); }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Normalize()
        {
            float mag = Magnitude(this);
            if (mag > 9.99999974737875E-06)
            {
                this = this/mag;
            }
            else
                Set(0f, 0f, 0f);
        }

        /// <summary>
        /// vector3 with all values set to 0
        /// </summary>
        public static Vector3 zero
        {
            get
            {
                return new Vector3(0f,0f,0f);
            }
        }

        /// <summary>
        /// vector3 with all values set to 1
        /// </summary>
        public readonly static Vector3 one = new Vector3(1f, 1f, 1f);
        /// <summary>
        /// vector3 with z set to 1
        /// </summary>
        public static Vector3 forward { get { return new Vector3(0f, 0f, 1f); } }
        /// <summary>
        /// 
        /// </summary>
        public static Vector3 back { get { return new Vector3(0f, 0f, -1f); } }
        /// <summary>
        /// 
        /// </summary>
        public static Vector3 up { get { return new Vector3(0f, 1f, 0f); } }
        /// <summary>
        /// 
        /// </summary>
        public static Vector3 down { get { return new Vector3(0f, -1f, 0f); } }
        /// <summary>
        /// 
        /// </summary>
        public static Vector3 left { get { return new Vector3(-1f, 0f, 0f); } }
        /// <summary>
        /// 
        /// </summary>
        public static Vector3 right { get { return new Vector3(1f, 0f, 0f); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.x*d, a.y*d, a.z*d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.x*d, a.y*d, a.z*d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.x/d, a.y/d, a.z/d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return SqrMagnitude(lhs - rhs) < 0.0/1.0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return SqrMagnitude(lhs - rhs) >= 0.0/1.0;
        }

        /// <summary>
        /// this is actually faster than unity's vector3.lerp, but functions the same
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 Lerp(Vector3 from, Vector3 to, float t)
        {
            if (t < 0f)
                return from;
            if (t > 1f)
                return to;
            return (to - from)*t + from;
        }
        
        
        /// <summary>
        /// NOT IMPELEMENTED
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Vector3 Slerp(Vector3 from, Vector3 to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="tangent"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent)
        {
            normal.Normalize();
            var proj = new Vector3();
            proj.Scale(normal);

            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="tangent"></param>
        /// <param name="binormal"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent, ref Vector3 binormal)
        {


            throw new NotImplementedException();
        }

        /// <summary>
        /// return a vector3 in the same direction as vector3, but with a magnitude of 1
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        private static Vector3 Normalize(Vector3 vector3)
        {
            var mag = Magnitude(vector3);
            if (mag > 9.99999974737875E-06)
                return vector3/mag;
            return zero;
        }

        private static float Magnitude(Vector3 vector3)
        {
            return vector3.magnitude;
        }

        private static float SqrMagnitude(Vector3 vector3)
        {
            return vector3.sqrMagnitude;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return (float)(lhs.x * (double)rhs.x + lhs.y * (double)rhs.y + lhs.z * (double)rhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="onNormal"></param>
        /// <returns></returns>
        public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            var dot = Dot(onNormal, onNormal);
            if (dot < 1.40129846432482E-45)
                return zero;
            return onNormal * Dot(vector, onNormal) / dot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excludeThis"></param>
        /// <param name="fromThat"></param>
        /// <returns></returns>
        public static Vector3 Exclude(Vector3 excludeThis, Vector3 fromThat)
        {
            return fromThat - Project(fromThat, excludeThis);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static float Angle(Vector3 from, Vector3 to)
        {
            return (float)Math.Acos(Mathf.Clamp(Dot(from.normalized, to.normalized), -1f, 1f)) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Distance(Vector3 a, Vector3 b)
        {
            return Magnitude(a - b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 Min(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 Max(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inDirection"></param>
        /// <param name="inNormal"></param>
        /// <returns></returns>
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
        {
            return -2f * Dot(inNormal, inDirection) * inNormal + inDirection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(Vector3 scale)
        {
            x *= scale.x;
            y *= scale.y;
            z *= scale.z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Scale(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3((float)(lhs.y * (double)rhs.z - lhs.z * (double)rhs.y), 
                (float)(lhs.z * (double)rhs.x - lhs.x * (double)rhs.z), 
                (float)(lhs.x * (double)rhs.y - lhs.y * (double)rhs.x));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed)
        {
            var deltaTime = Time.deltaTime;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime)
        {
            var deltaTime = Time.deltaTime;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, float.PositiveInfinity, deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = Mathf.Max(0.0001f, smoothTime);
            var num1 = 2f / smoothTime;
            var num2 = num1 * deltaTime;
            var num3 = (float)(1.0 / (1.0 + num2 + Mathf.MagicDamp1 * num2 * num2 + Mathf.MagicDamp2 * num2 * num2 * num2));
            var vector = current - target;
            var vector3_1 = target;
            var maxLength = maxSpeed * smoothTime;
            var vector3_2 = ClampMagnitude(vector, maxLength);
            target = current - vector3_2;
            var vector3_3 = (currentVelocity + num1 * vector3_2) * deltaTime;
            currentVelocity = (currentVelocity - num1 * vector3_3) * num3;
            var vector3_4 = target + (vector3_2 + vector3_3) * num3;
            if (Dot(vector3_1 - current, vector3_4 - vector3_1) > 0.0)
            {
                vector3_4 = vector3_1;
                currentVelocity = (vector3_4 - vector3_1) / deltaTime;
            }
            return vector3_4;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            var vector3 = target - current;
            var magnitude = vector3.magnitude;
// ReSharper disable CompareOfFloatsByEqualityOperator
            if (magnitude <= (double)maxDistanceDelta || magnitude == 0.0)
// ReSharper restore CompareOfFloatsByEqualityOperator
                return target;
            return current + vector3 / magnitude * maxDistanceDelta;
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxRadiansDelta"></param>
        /// <param name="maxMagnitudeDelta"></param>
        /// <returns></returns>
        public static Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta,
                                            float maxMagnitudeDelta)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
        {
            if (vector.sqrMagnitude > maxLength * (double)maxLength)
                return vector.normalized * maxLength;
            
            return vector;
        }

        public override string ToString()
        {
            return string.Format("({0:F1}, {1:F1}, {2:F1})", x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return string.Format("({0}, {1}, {2})", x.ToString(format), y.ToString(format), z.ToString(format));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newZ"></param>
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vector3 other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3 && Equals((Vector3)obj);
        }

        public override int GetHashCode()
        {
// ReSharper disable NonReadonlyFieldInGetHashCode
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2;
// ReSharper restore NonReadonlyFieldInGetHashCode
        }
    }
}