using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class Lid : ModelBase
    {
        [JsonProperty(PropertyName = "guid", NullValueHandling = NullValueHandling.Ignore)]
        public string Guid { get; set; }
        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public Point3d Position { get; set; }
        [JsonProperty(PropertyName = "diameter", NullValueHandling = NullValueHandling.Ignore)]
        public int Diameter { get; set; }
        [JsonProperty(PropertyName = "ladder", NullValueHandling = NullValueHandling.Ignore)]
        public string Ladder { get; set; }
        [JsonProperty(PropertyName = "classification", NullValueHandling = NullValueHandling.Ignore)]
        public string Classification { get; set; }
    }
}
