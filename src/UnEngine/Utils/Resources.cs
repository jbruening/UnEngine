using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UnityEngine
{
	public static class Resources
	{
		public static Object Load(string path)
		{
			return Load(path, null);
		}

		public static Object Load(string path, Type systemTypeInstance) 
        {
            Object asset = null;

            if (File.Exists (path))
            {
                Stream stream = File.OpenRead (path);
                XmlSerializer deserializer = new XmlSerializer (systemTypeInstance);
                asset = (Object)deserializer.Deserialize (stream);
                stream.Close ();
            }

            return asset; 
        }

        public static void Store<T>(string path, T asset)
        {
            Stream stream = File.Create (path);
            XmlSerializer serializer = new XmlSerializer (typeof(T));
            serializer.Serialize (stream, asset);
            stream.Close ();
	    }
    }
}
