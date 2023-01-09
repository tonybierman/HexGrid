using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBoard.Models
{
    // http://www.rpg-blog.com/2012/07/terrain-generator.html
    public enum TerrainType
    {
        [Description("None")] None = 0,
        [Description("Badlands")] Badlands = 1,
        [Description("Desert")] Desert = 2,
        [Description("Woodlands")] Woodlands = 3,
        [Description("Hills")] Hills = 4,
        [Description("Jungle")] Jungle = 5,
        [Description("Mountains")] Mountains = 6,
        [Description("Plains")] Plains = 7,
        [Description("Swamp")] Swamp = 8,
        [Description("Tundra")] Tundra = 9,
        [Description("Urban")] Urban = 10,
        [Description("Cultivated")] Cultivated = 11,
        [Description("Riparian")] Riparian = 12,
        [Description("Deep Water")] DeepWater = 13,
        [Description("Shallow Water")] ShallowWater = 14
    }
}
