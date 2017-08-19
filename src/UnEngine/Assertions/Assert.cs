using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine.Assertions.Comparers;

namespace UnityEngine.Assertions {
    /// <summary>
    ///   <para>The Assert class contains assertion methods for setting invariants in the code.</para>
    /// </summary>
    [DebuggerStepThrough]
    public static class Assert {
        internal const string UNITY_ASSERTIONS = "UNITY_ASSERTIONS";
        /// <summary>
        ///   <para>Should an exception be thrown on a failure.</para>
        /// </summary>
        public static bool raiseExceptions;

        private static void Fail(string message, string userMessage) {
            if (Debugger.IsAttached)
                throw new AssertionException(message, userMessage);
            if (Assert.raiseExceptions)
                throw new AssertionException(message, userMessage);
            if (message == null)
                message = "Assertion has failed\n";
            if (userMessage != null)
                message = userMessage + (object)'\n' + message;
            UnityEngine.Debug.LogAssertion((object)message);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Assert.Equals should not be used for Assertions", true)]
        public new static bool Equals(object obj1, object obj2) {
            throw new InvalidOperationException("Assert.Equals should not be used for Assertions");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Assert.ReferenceEquals should not be used for Assertions", true)]
        public new static bool ReferenceEquals(object obj1, object obj2) {
            throw new InvalidOperationException("Assert.ReferenceEquals should not be used for Assertions");
        }

        /// <summary>
        ///   <para>Asserts that the condition is true.</para>
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition) {
            Assert.IsTrue(condition, (string)null);
        }

        /// <summary>
        ///   <para>Asserts that the condition is true.</para>
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition, string message) {
            if (condition)
                return;
            Assert.Fail(AssertionMessageUtil.BooleanFailureMessage(true), message);
        }

        /// <summary>
        ///   <para>Asserts that the condition is false.</para>
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition) {
            Assert.IsFalse(condition, (string)null);
        }

        /// <summary>
        ///   <para>Asserts that the condition is false.</para>
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition, string message) {
            if (!condition)
                return;
            Assert.Fail(AssertionMessageUtil.BooleanFailureMessage(false), message);
        }

        /// <summary>
        ///         <para>Asserts that the values are approximately equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.
        /// 
        /// Note: Every time you call the method with tolerance specified, a new instance of Assertions.Comparers.FloatComparer is created. For performance reasons you might want to instance your own comparer and pass it to the AreEqual method. If the tolerance is not specifies, a default comparer is used and the issue does not occur.</para>
        ///       </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual) {
            Assert.AreEqual<float>(expected, actual, (string)null, (IEqualityComparer<float>)FloatComparer.s_ComparerWithDefaultTolerance);
        }

        /// <summary>
        ///         <para>Asserts that the values are approximately equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.
        /// 
        /// Note: Every time you call the method with tolerance specified, a new instance of Assertions.Comparers.FloatComparer is created. For performance reasons you might want to instance your own comparer and pass it to the AreEqual method. If the tolerance is not specifies, a default comparer is used and the issue does not occur.</para>
        ///       </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual, string message) {
            Assert.AreEqual<float>(expected, actual, message, (IEqualityComparer<float>)FloatComparer.s_ComparerWithDefaultTolerance);
        }

        /// <summary>
        ///         <para>Asserts that the values are approximately equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.
        /// 
        /// Note: Every time you call the method with tolerance specified, a new instance of Assertions.Comparers.FloatComparer is created. For performance reasons you might want to instance your own comparer and pass it to the AreEqual method. If the tolerance is not specifies, a default comparer is used and the issue does not occur.</para>
        ///       </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual, float tolerance) {
            Assert.AreApproximatelyEqual(expected, actual, tolerance, (string)null);
        }

        /// <summary>
        ///         <para>Asserts that the values are approximately equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.
        /// 
        /// Note: Every time you call the method with tolerance specified, a new instance of Assertions.Comparers.FloatComparer is created. For performance reasons you might want to instance your own comparer and pass it to the AreEqual method. If the tolerance is not specifies, a default comparer is used and the issue does not occur.</para>
        ///       </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message) {
            Assert.AreEqual<float>(expected, actual, message, (IEqualityComparer<float>)new FloatComparer(tolerance));
        }

        /// <summary>
        ///   <para>Asserts that the values are approximately not equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.</para>
        /// </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual) {
            Assert.AreNotEqual<float>(expected, actual, (string)null, (IEqualityComparer<float>)FloatComparer.s_ComparerWithDefaultTolerance);
        }

        /// <summary>
        ///   <para>Asserts that the values are approximately not equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.</para>
        /// </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual, string message) {
            Assert.AreNotEqual<float>(expected, actual, message, (IEqualityComparer<float>)FloatComparer.s_ComparerWithDefaultTolerance);
        }

        /// <summary>
        ///   <para>Asserts that the values are approximately not equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.</para>
        /// </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance) {
            Assert.AreNotApproximatelyEqual(expected, actual, tolerance, (string)null);
        }

        /// <summary>
        ///   <para>Asserts that the values are approximately not equal. An absolute error check is used for approximate equality check (|a-b| &lt; tolerance). Default tolerance is 0.00001f.</para>
        /// </summary>
        /// <param name="tolerance">Tolerance of approximation.</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message) {
            Assert.AreNotEqual<float>(expected, actual, message, (IEqualityComparer<float>)new FloatComparer(tolerance));
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual<T>(T expected, T actual) {
            Assert.AreEqual<T>(expected, actual, (string)null);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual<T>(T expected, T actual, string message) {
            Assert.AreEqual<T>(expected, actual, message, (IEqualityComparer<T>)EqualityComparer<T>.Default);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer) {
            if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T))) {
                Assert.AreEqual((object)expected as UnityEngine.Object, (object)actual as UnityEngine.Object, message);
            } else {
                if (comparer.Equals(actual, expected))
                    return;
                Assert.Fail(AssertionMessageUtil.GetEqualityMessage((object)actual, (object)expected, true), message);
            }
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(UnityEngine.Object expected, UnityEngine.Object actual, string message) {
            if (!(actual != expected))
                return;
            Assert.Fail(AssertionMessageUtil.GetEqualityMessage((object)actual, (object)expected, true), message);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual<T>(T expected, T actual) {
            Assert.AreNotEqual<T>(expected, actual, (string)null);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual<T>(T expected, T actual, string message) {
            Assert.AreNotEqual<T>(expected, actual, message, (IEqualityComparer<T>)EqualityComparer<T>.Default);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer) {
            if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T))) {
                Assert.AreNotEqual((object)expected as UnityEngine.Object, (object)actual as UnityEngine.Object, message);
            } else {
                if (!comparer.Equals(actual, expected))
                    return;
                Assert.Fail(AssertionMessageUtil.GetEqualityMessage((object)actual, (object)expected, false), message);
            }
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(UnityEngine.Object expected, UnityEngine.Object actual, string message) {
            if (!(actual == expected))
                return;
            Assert.Fail(AssertionMessageUtil.GetEqualityMessage((object)actual, (object)expected, false), message);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull<T>(T value) where T : class {
            Assert.IsNull<T>(value, (string)null);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull<T>(T value, string message) where T : class {
            if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T))) {
                Assert.IsNull((object)value as UnityEngine.Object, message);
            } else {
                if ((object)value == null)
                    return;
                Assert.Fail(AssertionMessageUtil.NullFailureMessage((object)value, true), message);
            }
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull(UnityEngine.Object value, string message) {
            if (!(value != (UnityEngine.Object)null))
                return;
            Assert.Fail(AssertionMessageUtil.NullFailureMessage((object)value, true), message);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNull<T>(T value) where T : class {
            Assert.IsNotNull<T>(value, (string)null);
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNull<T>(T value, string message) where T : class {
            if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T))) {
                Assert.IsNotNull((object)value as UnityEngine.Object, message);
            } else {
                if ((object)value != null)
                    return;
                Assert.Fail(AssertionMessageUtil.NullFailureMessage((object)value, false), message);
            }
        }

        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNotNull(UnityEngine.Object value, string message) {
            if (!(value == (UnityEngine.Object)null))
                return;
            Assert.Fail(AssertionMessageUtil.NullFailureMessage((object)value, false), message);
        }
    }
}
