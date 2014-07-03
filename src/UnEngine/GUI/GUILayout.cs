using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public static class GUILayout
    {
        public delegate void WindowFunction (int id);

		public static void BeginHorizontal() { }

		public static void EndHorizontal() { }

		public static bool Button(string text) { return false; }

        public static float HorizontalSlider (float value, float leftValue, float rightValue, params GUILayoutOption[] options) { return 0; }
        public static float HorizontalSlider (float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options) { return 0; }

        public static void Label (Texture image, params GUILayoutOption[] options) { }
        public static void Label (string text, params GUILayoutOption[] options) { }
        public static void Label (GUIContent content, params GUILayoutOption[] options) { }
        public static void Label (Texture image, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label (string text, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label (GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }

        public static bool Toggle (bool value, Texture image, params GUILayoutOption[] options) { return true; }
        public static bool Toggle (bool value, string text, params GUILayoutOption[] options) { return true; }
        public static bool Toggle (bool value, GUIContent content, params GUILayoutOption[] options) { return true; }
        public static bool Toggle (bool value, Texture image, GUIStyle style, params GUILayoutOption[] options) { return true; }
        public static bool Toggle (bool value, string text, GUIStyle style, params GUILayoutOption[] options) { return true; }
        public static bool Toggle (bool value, GUIContent content, GUIStyle style, params GUILayoutOption[] options) { return true; }

        public static Rect Window (int id, Rect screenRect, WindowFunction func, string text, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, Texture image, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, GUIContent content, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, string text, GUIStyle style, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, Texture image, GUIStyle style, params GUILayoutOption[] options) { return new Rect (); }
        public static Rect Window (int id, Rect screenRect, WindowFunction func, GUIContent content, GUIStyle style, params GUILayoutOption[] options) { return new Rect (); }
    }
}
