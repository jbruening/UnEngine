using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public struct Quaternion
    {
        /// <summary>
        /// 
        /// </summary>
        public const float kEpsilon = 1E-06f;

        /// <summary>
        /// 
        /// </summary>
        public float x;
        /// <summary>
        /// 
        /// </summary>
        public float y;
        /// <summary>
        /// 
        /// </summary>
        public float z;
        /// <summary>
        /// 
        /// </summary>
        public float w;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newZ"></param>
        /// <param name="newW"></param>
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
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
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
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
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 eulerAngles
        {
            get{return UnityStub_ToEulerRad(this) * Mathf.Rad2Deg;}
            set { this = UnityStub_FromEulerRad(value * (float) (Mathf.PI / 180.0));}
        }

        #region operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion((float)(lhs.w * (double)rhs.x + lhs.x * (double)rhs.w + lhs.y * (double)rhs.z - lhs.z * (double)rhs.y), 
                (float)(lhs.w * (double)rhs.y + lhs.y * (double)rhs.w + lhs.z * (double)rhs.x - lhs.x * (double)rhs.z), 
                (float)(lhs.w * (double)rhs.z + lhs.z * (double)rhs.w + lhs.x * (double)rhs.y - lhs.y * (double)rhs.x), 
                (float)(lhs.w * (double)rhs.w - lhs.x * (double)rhs.x - lhs.y * (double)rhs.y - lhs.z * (double)rhs.z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 operator *(Quaternion rotation, Vector3 point)
        {
            var num1 = rotation.x * 2f;
            var num2 = rotation.y * 2f;
            var num3 = rotation.z * 2f;
            var num4 = rotation.x * num1;
            var num5 = rotation.y * num2;
            var num6 = rotation.z * num3;
            var num7 = rotation.x * num2;
            var num8 = rotation.x * num3;
            var num9 = rotation.y * num3;
            var num10 = rotation.w * num1;
            var num11 = rotation.w * num2;
            var num12 = rotation.w * num3;
            Vector3 vector3;
            vector3.x = (float)((1.0 - (num5 + (double)num6)) * point.x + (num7 - (double)num12) * point.y + (num8 + (double)num11) * point.z);
            vector3.y = (float)((num7 + (double)num12) * point.x + (1.0 - (num4 + (double)num6)) * point.y + (num9 - (double)num10) * point.z);
            vector3.z = (float)((num8 - (double)num11) * point.x + (num9 + (double)num10) * point.y + (1.0 - (num4 + (double)num5)) * point.z);
            return vector3;
        }

        private const double equalityEpsilon = 0.999998986721039;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Quaternion lhs, Quaternion rhs)
        {
            return Dot(lhs, rhs) > equalityEpsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Quaternion lhs, Quaternion rhs)
        {
            return Dot(lhs, rhs) <= equalityEpsilon;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Dot(Quaternion a, Quaternion b)
        {
            return (float)(a.x * (double)b.x + a.y * (double)b.y + a.z * (double)b.z + a.w * (double)b.w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        public void ToAngleAxis(out float angle, out Vector3 axis)
        {
            UnityStub_ToAxisAngleRad(this, out axis, out angle);
            angle = angle * Mathf.Rad2Deg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDirection"></param>
        /// <param name="toDirection"></param>
        /// <returns></returns>
        public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDirection"></param>
        /// <param name="toDirection"></param>
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            this = FromToRotation(fromDirection, toDirection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forward"></param>
        /// <param name="upwards"></param>
        /// <returns></returns>
        public static Quaternion LookRotation(Vector3 forward, Vector3 upwards)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forward"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Quaternion LookRotation(Vector3 forward)
        {
            return LookRotation(forward, Vector3.up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public void SetLookRotation(Vector3 view)
        {
            SetLookRotation(view, Vector3.up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="up"></param>
        public void SetLookRotation(Vector3 view, Vector3 up)
        {
            this = LookRotation(view, up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Quaternion Slerp(Quaternion from, Quaternion to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="maxDegreesDelta"></param>
        /// <returns></returns>
        public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta)
        {
            var t = Mathf.Min(1f, maxDegreesDelta / Angle(from, to));
            return UnclampedSlerp(from, to, t);
        }

        private static Quaternion UnclampedSlerp(Quaternion from, Quaternion to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Quaternion Inverse(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Quaternion Lerp(Quaternion from, Quaternion to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Angle(Quaternion a, Quaternion b)
        {
            return (float)(Math.Acos(Math.Min(Math.Abs(Dot(a, b)), 1f)) * 2.0 * 57.2957801818848);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Quaternion Euler(float x, float y, float z)
        {
            return UnityStub_FromEulerRad(new Vector3(x, y, z) * (float) (Math.PI / 180.0));
        }

        private static void UnityStub_ToAxisAngleRad(Quaternion rotation, out Vector3 axis, out float angle)
        {
            throw new NotImplementedException();
        }

        private static Quaternion UnityStub_FromEulerRad(Vector3 euler)
        {
            throw new NotImplementedException();
        }

        private static Vector3 UnityStub_ToEulerRad(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
// ReSharper disable NonReadonlyFieldInGetHashCode
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2 ^ w.GetHashCode() >> 1;
// ReSharper restore NonReadonlyFieldInGetHashCode
        }

        public override bool Equals(object other)
        {
            if (!(other is Quaternion))
                return false;
            var quaternion = (Quaternion)other;
            if (x.Equals(quaternion.x) && y.Equals(quaternion.y) && z.Equals(quaternion.z))
                return w.Equals(quaternion.w);
            return false;
        }
    }
}
