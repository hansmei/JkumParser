using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class PipeConnection : ModelBase
    {
        [JsonProperty(PropertyName = "guid", Required = Required.Always)]
        public string Guid { get; set; }
        [JsonProperty(PropertyName = "sid", NullValueHandling = NullValueHandling.Ignore)]
        public string Sid { get; set; }
        [JsonProperty(PropertyName = "medium", NullValueHandling = NullValueHandling.Ignore)]
        public string Medium { get; set; }
        [JsonProperty(PropertyName = "direction", NullValueHandling = NullValueHandling.Ignore)]
        public string Direction { get; set; }
        [JsonProperty(PropertyName = "pressurized", Required = Required.Always)]
        public bool Pressurized { get; set; }
        [JsonProperty(PropertyName = "elevation", Required = Required.Always)]
        public double Elevation { get; set; }
        [JsonProperty(PropertyName = "clockPosition", Required = Required.Always)]
        public int ClockPosition { get; set; }
        [JsonProperty(PropertyName = "diameter", Required = Required.Always)]
        public int Diameter { get; set; }
    }
}
