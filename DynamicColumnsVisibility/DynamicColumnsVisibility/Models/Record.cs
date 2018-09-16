using System.Collections.Generic;

namespace DynamicColumnsVisibility.Models
{
    public class Record
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public Record(params KeyValuePair<string, object>[] properties)
        {
            foreach (var property in properties)
            {
                Properties.Add(property.Key, property.Value);
            }
        }

        public Dictionary<string, object> Properties
        {
            get { return _properties; }
        }
    }
}