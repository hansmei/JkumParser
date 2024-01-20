using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class Manhole : ModelBase
    {
        [JsonProperty(PropertyName = "guid",  Required = Newtonsoft.Json.Required.Always)]
        public string Guid { get; set; }
        [JsonProperty(PropertyName = "sid", NullValueHandling = NullValueHandling.Ignore)]
        public string Sid { get; set; }
        [JsonProperty(PropertyName = "bottomCenter", NullValueHandling = NullValueHandling.Ignore)]
        public Point3d BottomCenter { get; set; }
        [JsonProperty(PropertyName = "shape", NullValueHandling = NullValueHandling.Ignore)]
        public string Shape { get; set; }
        [JsonProperty(PropertyName = "diameter", NullValueHandling = NullValueHandling.Ignore)]
        public int Diameter { get; set; }
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "length", NullValueHandling = NullValueHandling.Ignore)]
        public int Length { get; set; }
        [JsonProperty(PropertyName = "material", NullValueHandling = NullValueHandling.Ignore)]
        public string Material { get; set; }
        [JsonProperty(PropertyName = "imageData", NullValueHandling = NullValueHandling.Ignore)]
        public List<ImageData> ImageData { get; set; }

        [JsonProperty(PropertyName = "lids", NullValueHandling = NullValueHandling.Ignore)]
        public List<Lid> Lids { get; set; }

        [JsonProperty(PropertyName = "pipeConnections", NullValueHandling = NullValueHandling.Ignore)]
        public List<PipeConnection> PipeConnections { get; set; }

        [JsonProperty(PropertyName = "circumference", NullValueHandling = NullValueHandling.Ignore)]
        public ManholeCircumference Circumference { get; set; }

    }
}
