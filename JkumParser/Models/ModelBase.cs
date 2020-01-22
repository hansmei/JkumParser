using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class ModelBase : IModel
    {
        public string ToJson(JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(this, settings);
        }
        public T FromJson<T>(string jsonString, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }
    }
}
