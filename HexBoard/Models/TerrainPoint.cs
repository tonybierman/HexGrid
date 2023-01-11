using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HexBoard.Models
{
    public class TerrainPoint : INotifyPropertyChanged
    {
        private TerrainType _terrainType;

        public IntPoint? Point { get; set; }

        public TerrainType Terrain 
        {
            get
            {
                return _terrainType;
            }
            set
            {
                if (_terrainType != value)
                {
                    _terrainType = value;
                    OnPropertyChanged(nameof(Terrain));
                    OnPropertyChanged(nameof(TerrainTypeAsInt));
                }
            }
        }

        public int TerrainTypeAsInt { get { return (int)Terrain; } }

        public TerrainPoint(int c, int r) 
        {
            Point = new IntPoint(c, r);
            Terrain = TerrainType.Plains;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
