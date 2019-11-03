using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;

namespace MyAssistant.Core.Services
{
    public class JsonIOService
    {
        /// <summary>
        /// Read JSON from file and convert to JObject
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public JObject ReadFromFile(string filePath)
        {
            try
            {
                // Read JSON string from file
                string json;
                using (var sr = new StreamReader(filePath))
                    json = sr.ReadToEnd();
                return JObject.Parse(json);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Convert JSon object to string and write to file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jObject"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public bool WriteToFile(string filePath, JObject jObject, bool append = false)
        {
            try
            {
                using (var sw = new StreamWriter(filePath, append))
                    sw.Write(jObject.ToString());
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
