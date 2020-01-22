using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class Jkum : ModelBase
    {
        [JsonProperty(PropertyName = "head", Required = Newtonsoft.Json.Required.Always)]
        public Head Head { get; set; }
        [JsonProperty(PropertyName = "manholes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Manhole> Manholes { get; set; }
    }
}
