using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Utilities
{
    public static class JsonHelper
    {
        public static JObject Read(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject jObject = (JObject)JToken.ReadFrom(reader);
                    return jObject;
                }
            }
        }

        public static void Write(string filePath, string key, object value)
        {
            JObject jOject = new JObject(new JProperty(key, value));
            File.WriteAllText(filePath, jOject.ToString());
            using (StreamWriter file = File.CreateText(filePath))
            {
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    jOject.WriteTo(writer);
                }
            }
        }
    }
}