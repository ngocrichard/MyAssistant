using Caliburn.Micro;
using System;

namespace MyAssistant
{
    /// <summary>
    /// Support alternate syntax for IoC Container
    /// </summary>
    public static class IoCExtension
    {
        /// <summary>
        /// Get an instance from container
        /// </summary>
        /// <param name="type">Type to resolve</param>
        /// <param name="key">Key to hook up</param>
        /// <returns></returns>
        public static object Get(Type type, string key = null)
        {
            if (type == null)
                throw new ArgumentNullException("Type cannot be null.");

            // Use reflection to get IoC.Get<T>(string key = null) method
            var getMethod = typeof(IoC).GetMethod("Get").MakeGenericMethod(type);

            // Invoke the method, first null object represents the static method
            return getMethod.Invoke(null, new object[] { key });
        }
    }
}
