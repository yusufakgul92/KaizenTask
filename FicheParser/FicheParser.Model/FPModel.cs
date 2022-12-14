using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheParser.Model
{
    public class BoundingPoly
    {
        [JsonProperty("vertices")]
        public List<Vertex> Vertices { get; set; }
    }

    public class Vertex
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
    public class FPModel
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("boundingPoly")]
        public BoundingPoly BoundingPoly { get; set; }
    }
}
