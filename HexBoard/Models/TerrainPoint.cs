using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HexBoard.Models
{
    public class TerrainPoint
    {
        public IntPoint Point { get; set; }

        public TerrainType Terrain { get; set; }

        public TerrainPoint(int c, int r) 
        {
            Point = new IntPoint(c, r);
            Terrain = TerrainType.None;
        }
    }
}
