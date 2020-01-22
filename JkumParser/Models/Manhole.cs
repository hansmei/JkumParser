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
        [JsonProperty(PropertyName = "elementId", NullValueHandling = NullValueHandling.Ignore)]
        public string ElementId { get; set; }
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
        [JsonProperty(PropertyName = "rotation", NullValueHandling = NullValueHandling.Ignore)]
        public int Rotation { get; set; }
        [JsonProperty(PropertyName = "material", NullValueHandling = NullValueHandling.Ignore)]
        public string Material { get; set; }
        [JsonProperty(PropertyName = "imageString", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageString { get; set; }
        [JsonProperty(PropertyName = "imageType", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageType { get; set; }
        [JsonProperty(PropertyName = "imageRelativePath", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageRelativePath { get; set; }

        [JsonProperty(PropertyName = "lids", NullValueHandling = NullValueHandling.Ignore)]
        public List<Lid> Lids { get; set; }

        [JsonProperty(PropertyName = "links", NullValueHandling = NullValueHandling.Ignore)]
        public List<ManholeLink> Links { get; set; }

        [JsonProperty(PropertyName = "circumference", NullValueHandling = NullValueHandling.Ignore)]
        public ManholeCircumference Circumference { get; set; }

    }
}
