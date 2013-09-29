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
    public static class Mathf
    {
        /// <summary>
        /// 
        /// </summary>
        public const float PI = 3.141593f;
        /// <summary>
        /// 
        /// </summary>
        public const float Infinity = float.PositiveInfinity;
        /// <summary>
        /// 
        /// </summary>
        public const float NegativeInfinity = float.NegativeInfinity;
        /// <summary>
        /// 
        /// </summary>
        public const float Deg2Rad = 0.01745329f;
        /// <summary>
        /// 
        /// </summary>
        public const float Rad2Deg = 57.29578f;
        /// <summary>
        /// 
        /// </summary>
        public const float Epsilon = 1.401298E-45f;

        internal const double MagicDamp1 = 0.479999989271164;
        internal const double MagicDamp2 = 0.234999999403954;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Sin(float f)
        {
            return (float)Math.Sin(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Cos(float f)
        {
            return (float)Math.Cos(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Tan(float f)
        {
            return (float)Math.Tan(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Asin(float f)
        {
            return (float)Math.Asin(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Acos(float f)
        {
            return (float)Math.Acos(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Atan(float f)
        {
            return (float)Math.Atan(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Abs(float f)
        {
            return Math.Abs(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Abs(int value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Min(float a, float b)
        {
            return (double)a < b ? a : b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static float Min(params float[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0.0f;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] < (double)num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int Min(params int[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] < num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Max(float a, float b)
        {
            return a > (double)b ? a : b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static float Max(params float[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0.0f;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] > (double)num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int Max(params int[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] > num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float Pow(float f, float p)
        {
            return (float)Math.Pow(f, p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public static float Exp(float power)
        {
            return (float)Math.Exp(power);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float Log(float f, float p)
        {
            return (float)Math.Log(f, p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Log(float f)
        {
            return (float)Math.Log(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Log10(float f)
        {
            return (float)Math.Log10(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Ceil(float f)
        {
            return (float)Math.Ceiling(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Floor(float f)
        {
            return (float)Math.Floor(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Round(float f)
        {
            return (float)Math.Round(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int CeilToInt(float f)
        {
            return (int)Math.Ceiling(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int FloorToInt(float f)
        {
            return (int)Math.Floor(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int RoundToInt(float f)
        {
            return (int)Math.Round(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Sign(float f)
        {
            return (double)f >= 0.0 ? 1f : -1f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Clamp(float value, float min, float max)
        {
            if ((double)value < min)
                value = min;
            else if ((double)value > max)
                value = max;
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Clamp01(float value)
        {
            if (value < 0f)
                return 0f;
            return value > 1.0 ? 1f : value;
        }

        /// <summary>
        /// faster than unity's lerp
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float Lerp(float from, float to, float t)
        {
            if (t < 0.0f)
                return from;
            if (t > 1.0f)
                return to;
            return (to - from) * t + from;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float LerpAngle(float a, float b, float t)
        {
            var num = Repeat(b - a, 360f);
            if (num > 180.0)
                num -= 360f;
            return a + num * Clamp01(t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        /// <returns></returns>
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            if (Math.Abs(target - current) <= (double)maxDelta)
                return target;
            return current + Sign(target - current) * maxDelta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        /// <returns></returns>
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            target = current + DeltaAngle(current, target);
            return MoveTowards(current, target, maxDelta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float SmoothStep(float from, float to, float t)
        {
            if (t < 0.0f)
                return from;
            if (t > 1.0f)
                return to;
            t = t * t * (3.0f - 2.0f * t);
            return (1.0f - t) * from + t * to;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="absmax"></param>
        /// <param name="gamma"></param>
        /// <returns></returns>
        public static float Gamma(float value, float absmax, float gamma)
        {
            var flag = value < 0.0;
            var num1 = Abs(value);
            if (num1 > (double)absmax)
            {
                if (flag)
                    return -num1;
                return num1;
            }
            
            var num2 = Pow(num1 / absmax, gamma) * absmax;
            if (flag)
                return -num2;
            return num2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Approximately(float a, float b)
        {
            return Abs(b - a) < (double)Max(1E-06f * Max(Abs(a), Abs(b)), 1.121039E-44f);
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
        /// <exception cref="NotImplementedException"></exception>
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
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
        /// <exception cref="NotImplementedException"></exception>
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime)
        {
            var deltaTime = Time.deltaTime;
            const float maxSpeed = float.PositiveInfinity;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
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
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = Max(0.0001f, smoothTime);
            var num1 = 2f / smoothTime;
            var num2 = num1 * deltaTime;
            var num3 = (float)(1.0 / (1.0 + num2 + MagicDamp1 * num2 * num2 + MagicDamp2 * num2 * num2 * num2));
            var num4 = current - target;
            var num5 = target;
            var max = maxSpeed * smoothTime;
            var num6 = Clamp(num4, -max, max);
            target = current - num6;
            var num7 = (currentVelocity + num1 * num6) * deltaTime;
            currentVelocity = (currentVelocity - num1 * num7) * num3;
            var num8 = target + (num6 + num7) * num3;
            if (num5 - (double)current > 0.0 == num8 > (double)num5)
            {
                num8 = num5;
                currentVelocity = (num8 - num5) / deltaTime;
            }
            return num8;
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
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
        {
            var deltaTime = Time.deltaTime;
            return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime)
        {
            var deltaTime = Time.deltaTime;
            const float maxSpeed = float.PositiveInfinity;
            return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
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
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            target = current + DeltaAngle(current, target);
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static float Repeat(float t, float length)
        {
            return (float) (t - Math.Floor(t / length) * length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static float PingPong(float t, float length)
        {
            t = Repeat(t, length * 2f);
            return length - Math.Abs(t - length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float InverseLerp(float from, float to, float value)
        {            
            if (from < to)
            {
                if (value < from)
                    return 0.0f;
                if (value > to)
                    return 1.0f;
            }
            else
            {
                if (value < to)
                    return 1.0f;
                if (value > @from)
                    return 0.0f;
            }
            return (value - from) / (to - from);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static float DeltaAngle(float current, float target)
        {
            var num = Repeat(target - current, 360f);
            if (num > 180.0)
                num -= 360f;
            return num;
        }
    }
}