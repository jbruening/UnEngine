using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
    public static class GUILayout
    {
        public delegate void WindowFunction (int id);

        public static void Label (Texture image, params GUILayoutOption[] options) { }
        public static void Label (string text, params GUILayoutOption[] options) { }
        public static void Label (GUIContent content, params GUILayoutOption[] options) { }
        public static void Label (Texture image, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label (string text, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label (GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }

        public static Rect Window (int id, Rect screenRect, WindowFunction func, string text, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, Texture image, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, GUIContent content, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, string text, GUIStyle style, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, Texture image, GUIStyle style, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, GUIContent content, GUIStyle style, params GUILayoutOption[] options) { return new Rect (); }
    }
}
