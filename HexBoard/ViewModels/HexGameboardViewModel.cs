using HexBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBoard.ViewModels
{
    public class HexGameboardViewModel
    {
        public List<TerrainPoint> Grid { get; private set; }

        public HexGameboardViewModel(int cc, int rc)
        {
            Grid =
                 Enumerable.Range(0, rc)
                     .SelectMany(r => Enumerable.Range(0, cc)
                     .Select(c => new TerrainPoint(c, r)))
                     .ToList();
        }
    }
}
