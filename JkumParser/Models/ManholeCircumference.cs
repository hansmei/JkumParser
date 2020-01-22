using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class ManholeCircumference : ModelBase
    {
        [JsonProperty(PropertyName = "innerVertices", NullValueHandling = NullValueHandling.Ignore)]
        public List<Point3d> InnerVertices { get; set; }
        [JsonProperty(PropertyName = "outerVertices", NullValueHandling = NullValueHandling.Ignore)]
        public List<Point3d> OuterVertices { get; set; }
    }
}
