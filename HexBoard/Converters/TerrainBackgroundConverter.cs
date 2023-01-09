using HexBoard.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HexBoard.Converters
{
    public class TerrainBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            { 
            
                TerrainType tt = (TerrainType)value;

                switch(tt)
                {
                    case TerrainType.Plains:
                        return "green";
                    case TerrainType.ShallowWater:
                        return "blue";
                }

            }

            return "#ffffff";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
