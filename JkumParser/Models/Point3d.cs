using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    [Serializable]
    public class Point3d : ModelBase
    {
        [JsonProperty(PropertyName = "east", Required = Newtonsoft.Json.Required.Always)]
        public double East { get; set; }
        [JsonProperty(PropertyName = "north", Required = Newtonsoft.Json.Required.Always)]
        public double North { get; set; }
        [JsonProperty(PropertyName = "elevation", Required = Newtonsoft.Json.Required.Always)]
        public double Elevation { get; set; }

        public Point3d() { }

        public Point3d(double east, double north, double elevation)
        {
            this.East = east;
            this.North = north;
            this.Elevation = elevation;
        }
    }
}
