using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class Head : ModelBase
    {
        [JsonProperty(PropertyName = "epsg", Required = Required.Always)]
        public string EPSG { get; set; }
        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Include)]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Include)]
        public string Author { get; set; }
    }
}
