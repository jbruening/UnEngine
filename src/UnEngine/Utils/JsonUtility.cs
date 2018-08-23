using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace UnityEngine {
    /// <summary>
    ///   <para>Utility functions for working with JSON data.</para>
    /// </summary>
    public static class JsonUtility {
        /// <summary>
        ///   <para>Generate a JSON representation of the public fields of an object.</para>
        /// </summary>
        /// <param name="obj">The object to convert to JSON form.</param>
        /// <param name="prettyPrint">If true, format the output for readability. If false, format the output for minimum size. Default is false.</param>
        /// <returns>
        ///   <para>The object's data in JSON format.</para>
        /// </returns>
        public static string ToJson(object obj) {
            return JsonUtility.ToJson(obj, false);
        }

        /// <summary>
        ///   <para>Generate a JSON representation of the public fields of an object.</para>
        /// </summary>
        /// <param name="obj">The object to convert to JSON form.</param>
        /// <param name="prettyPrint">If true, format the output for readability. If false, format the output for minimum size. Default is false.</param>
        /// <returns>
        ///   <para>The object's data in JSON format.</para>
        /// </returns>
        public static string ToJson(object obj, bool prettyPrint) {
            return JsonConvert.SerializeObject(obj, prettyPrint ? Formatting.Indented : Formatting.None);
        }

        public static T FromJson<T>(string json) {
            return (T)JsonUtility.FromJson(json, typeof(T));
        }

        /// <summary>
        ///   <para>Create an object from its JSON representation.</para>
        /// </summary>
        /// <param name="json">The JSON representation of the object.</param>
        /// <param name="type">The type of object represented by the Json.</param>
        /// <returns>
        ///   <para>An instance of the object.</para>
        /// </returns>
        public static object FromJson(string json, System.Type type) {
            return JsonConvert.DeserializeObject(json, type);
        }

        /// <summary>
        ///   <para>Overwrite data in an object by reading from its JSON representation.</para>
        /// </summary>
        /// <param name="json">The JSON representation of the object.</param>
        /// <param name="objectToOverwrite">The object that should be overwritten.</param>
        public static void FromJsonOverwrite(string json, object objectToOverwrite) {
            throw new System.NotImplementedException();
        }
    }
}
