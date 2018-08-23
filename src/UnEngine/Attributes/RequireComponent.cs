using System;

namespace UnityEngine {
    /// <summary>
    ///   <para>The RequireComponent attribute automatically adds required components as dependencies.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
#pragma warning disable S3376 // Attribute, EventArgs, and Exception type names should end with the type being extended
    public sealed class RequireComponent : Attribute {
#pragma warning restore S3376 // Attribute, EventArgs, and Exception type names should end with the type being extended
        public System.Type m_Type0;
        public System.Type m_Type1;
        public System.Type m_Type2;

        /// <summary>
        ///   <para>Require a single component.</para>
        /// </summary>
        /// <param name="requiredComponent"></param>
        public RequireComponent(System.Type requiredComponent) {
            this.m_Type0 = requiredComponent;
        }

        /// <summary>
        ///   <para>Require two components.</para>
        /// </summary>
        /// <param name="requiredComponent"></param>
        /// <param name="requiredComponent2"></param>
        public RequireComponent(System.Type requiredComponent, System.Type requiredComponent2) {
            this.m_Type0 = requiredComponent;
            this.m_Type1 = requiredComponent2;
        }

        /// <summary>
        ///   <para>Require three components.</para>
        /// </summary>
        /// <param name="requiredComponent"></param>
        /// <param name="requiredComponent2"></param>
        /// <param name="requiredComponent3"></param>
        public RequireComponent(System.Type requiredComponent, System.Type requiredComponent2, System.Type requiredComponent3) {
            this.m_Type0 = requiredComponent;
            this.m_Type1 = requiredComponent2;
            this.m_Type2 = requiredComponent3;
        }
    }
}
