using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class ImageData : ModelBase
    {
        [JsonProperty(PropertyName = "base64String", NullValueHandling = NullValueHandling.Ignore)]
        public string Base64String { get; set; }
        [JsonProperty(PropertyName = "imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }
    }
}
