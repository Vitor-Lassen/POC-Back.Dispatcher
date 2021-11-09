using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Utils
{
    public static class DictionaryExtensions
    {
        public static IDictionary<string,object> ToDictionary <TEntity>(this TEntity source)  where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException("source", "Unable to convert object to a dictionary. The source object is null.");

            var dictionary = new Dictionary<string, object>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                dictionary.Add(property.Name, value);
            }        
            return dictionary;
        }
    }
}
