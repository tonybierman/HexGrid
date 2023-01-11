using HexBoard.Models;
using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HexBoard.ViewModels
{
    public class HexGameboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<TerrainPoint> Grid { get; private set; }

        public HexGameboardViewModel(int cc, int rc)
        {
            var hexs = Enumerable.Range(0, rc)
                     .SelectMany(r => Enumerable.Range(0, cc)
                     .Select(c => new TerrainPoint(c, r)))
                     .ToArray();

            Grid = new ObservableCollection<TerrainPoint>();

            foreach (var hex in hexs)
            {
                Grid.Add(hex);
            }

            HexArrayHelper hah = new HexArrayHelper();


            foreach (var g in Grid)
            {
                g.Terrain = TerrainType.Plains;

                //if (g.Point?.X == 0 && g.Point?.Y == 0)
                //{
                //    var hexes = hah.GetRay(new IntSize(cc, rc), (IntPoint)g.Point, HexDirection.DownRight);
                //    foreach (var h in hexes)
                //    {
                //        var tp = GetTerrainAt(h.X, h.Y);
                //        if (tp != null)
                //            tp.Terrain = TerrainType.ShallowWater;
                //    }
                //}
            }
            
        }

        public void ChangeTerrain(TerrainPoint point, TerrainType tt)
        {
            point.Terrain = tt;
            OnPropertyChanged(nameof(Grid));
        }

        private TerrainPoint GetTerrainAt(int x, int y)
        {
            return Grid.Where(a => a.Point?.X == x && a.Point?.Y == y).FirstOrDefault();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
