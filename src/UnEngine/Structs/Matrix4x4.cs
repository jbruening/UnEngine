using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public struct Matrix4x4
    {
        public float m00;
        public float m10;
        public float m20;
        public float m30;
        public float m01;
        public float m11;
        public float m21;
        public float m31;
        public float m02;
        public float m12;
        public float m22;
        public float m32;
        public float m03;
        public float m13;
        public float m23;
        public float m33;

        public float this[int row, int column]
        {
            get { return this[row + column*4]; }
            set { this[row + column*4] = value; }
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return m00;
                    case 1:
                        return m10;
                    case 2:
                        return m20;
                    case 3:
                        return m30;
                    case 4:
                        return m01;
                    case 5:
                        return m11;
                    case 6:
                        return m21;
                    case 7:
                        return m31;
                    case 8:
                        return m02;
                    case 9:
                        return m12;
                    case 10:
                        return m22;
                    case 11:
                        return m32;
                    case 12:
                        return m03;
                    case 13:
                        return m13;
                    case 14:
                        return m23;
                    case 15:
                        return m33;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        m00 = value;
                        break;
                    case 1:
                        m10 = value;
                        break;
                    case 2:
                        m20 = value;
                        break;
                    case 3:
                        m30 = value;
                        break;
                    case 4:
                        m01 = value;
                        break;
                    case 5:
                        m11 = value;
                        break;
                    case 6:
                        m21 = value;
                        break;
                    case 7:
                        m31 = value;
                        break;
                    case 8:
                        m02 = value;
                        break;
                    case 9:
                        m12 = value;
                        break;
                    case 10:
                        m22 = value;
                        break;
                    case 11:
                        m32 = value;
                        break;
                    case 12:
                        m03 = value;
                        break;
                    case 13:
                        m13 = value;
                        break;
                    case 14:
                        m23 = value;
                        break;
                    case 15:
                        m33 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        public Vector4 GetColumn(int i)
        {
            return new Vector4(this[0, i], this[1, i], this[2, i], this[3, i]);
        }

        public static Matrix4x4 zero
        {
            get
            {
                return new Matrix4x4()
                {
                    m00 = 0.0f,
                    m01 = 0.0f,
                    m02 = 0.0f,
                    m03 = 0.0f,
                    m10 = 0.0f,
                    m11 = 0.0f,
                    m12 = 0.0f,
                    m13 = 0.0f,
                    m20 = 0.0f,
                    m21 = 0.0f,
                    m22 = 0.0f,
                    m23 = 0.0f,
                    m30 = 0.0f,
                    m31 = 0.0f,
                    m32 = 0.0f,
                    m33 = 0.0f
                };
            }
        }

        public static Matrix4x4 identity
        {
            get
            {
                return new Matrix4x4()
                {
                    m00 = 1f,
                    m01 = 0.0f,
                    m02 = 0.0f,
                    m03 = 0.0f,
                    m10 = 0.0f,
                    m11 = 1f,
                    m12 = 0.0f,
                    m13 = 0.0f,
                    m20 = 0.0f,
                    m21 = 0.0f,
                    m22 = 1f,
                    m23 = 0.0f,
                    m30 = 0.0f,
                    m31 = 0.0f,
                    m32 = 0.0f,
                    m33 = 1f
                };
            }
        }

        #region operators
        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            return new Matrix4x4()
            {
                m00 = (float)(lhs.m00 * (double)rhs.m00 + lhs.m01 * (double)rhs.m10 + lhs.m02 * (double)rhs.m20 + lhs.m03 * (double)rhs.m30),
                m01 = (float)(lhs.m00 * (double)rhs.m01 + lhs.m01 * (double)rhs.m11 + lhs.m02 * (double)rhs.m21 + lhs.m03 * (double)rhs.m31),
                m02 = (float)(lhs.m00 * (double)rhs.m02 + lhs.m01 * (double)rhs.m12 + lhs.m02 * (double)rhs.m22 + lhs.m03 * (double)rhs.m32),
                m03 = (float)(lhs.m00 * (double)rhs.m03 + lhs.m01 * (double)rhs.m13 + lhs.m02 * (double)rhs.m23 + lhs.m03 * (double)rhs.m33),
                m10 = (float)(lhs.m10 * (double)rhs.m00 + lhs.m11 * (double)rhs.m10 + lhs.m12 * (double)rhs.m20 + lhs.m13 * (double)rhs.m30),
                m11 = (float)(lhs.m10 * (double)rhs.m01 + lhs.m11 * (double)rhs.m11 + lhs.m12 * (double)rhs.m21 + lhs.m13 * (double)rhs.m31),
                m12 = (float)(lhs.m10 * (double)rhs.m02 + lhs.m11 * (double)rhs.m12 + lhs.m12 * (double)rhs.m22 + lhs.m13 * (double)rhs.m32),
                m13 = (float)(lhs.m10 * (double)rhs.m03 + lhs.m11 * (double)rhs.m13 + lhs.m12 * (double)rhs.m23 + lhs.m13 * (double)rhs.m33),
                m20 = (float)(lhs.m20 * (double)rhs.m00 + lhs.m21 * (double)rhs.m10 + lhs.m22 * (double)rhs.m20 + lhs.m23 * (double)rhs.m30),
                m21 = (float)(lhs.m20 * (double)rhs.m01 + lhs.m21 * (double)rhs.m11 + lhs.m22 * (double)rhs.m21 + lhs.m23 * (double)rhs.m31),
                m22 = (float)(lhs.m20 * (double)rhs.m02 + lhs.m21 * (double)rhs.m12 + lhs.m22 * (double)rhs.m22 + lhs.m23 * (double)rhs.m32),
                m23 = (float)(lhs.m20 * (double)rhs.m03 + lhs.m21 * (double)rhs.m13 + lhs.m22 * (double)rhs.m23 + lhs.m23 * (double)rhs.m33),
                m30 = (float)(lhs.m30 * (double)rhs.m00 + lhs.m31 * (double)rhs.m10 + lhs.m32 * (double)rhs.m20 + lhs.m33 * (double)rhs.m30),
                m31 = (float)(lhs.m30 * (double)rhs.m01 + lhs.m31 * (double)rhs.m11 + lhs.m32 * (double)rhs.m21 + lhs.m33 * (double)rhs.m31),
                m32 = (float)(lhs.m30 * (double)rhs.m02 + lhs.m31 * (double)rhs.m12 + lhs.m32 * (double)rhs.m22 + lhs.m33 * (double)rhs.m32),
                m33 = (float)(lhs.m30 * (double)rhs.m03 + lhs.m31 * (double)rhs.m13 + lhs.m32 * (double)rhs.m23 + lhs.m33 * (double)rhs.m33)
            };
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 v)
        {
            Vector4 vector4;
            vector4.x = (float)(lhs.m00 * (double)v.x + lhs.m01 * (double)v.y + lhs.m02 * (double)v.z + lhs.m03 * (double)v.w);
            vector4.y = (float)(lhs.m10 * (double)v.x + lhs.m11 * (double)v.y + lhs.m12 * (double)v.z + lhs.m13 * (double)v.w);
            vector4.z = (float)(lhs.m20 * (double)v.x + lhs.m21 * (double)v.y + lhs.m22 * (double)v.z + lhs.m23 * (double)v.w);
            vector4.w = (float)(lhs.m30 * (double)v.x + lhs.m31 * (double)v.y + lhs.m32 * (double)v.z + lhs.m33 * (double)v.w);
            return vector4;
        }

        public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            if (lhs.GetColumn(0) == rhs.GetColumn(0) && lhs.GetColumn(1) == rhs.GetColumn(1) && lhs.GetColumn(2) == rhs.GetColumn(2))
                return lhs.GetColumn(3) == rhs.GetColumn(3);
            else
                return false;
        }

        public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            return !(lhs == rhs);
        }

        #endregion
    }
}