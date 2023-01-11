using HexBoard.Models;
using HexBoard.ViewModels;
using HexGridHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HexBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HexGameboardViewModel vm = new HexGameboardViewModel(Board.ColumnCount, Board.RowCount);

            DataContext = vm;

            Board.ItemsSource = vm.Grid;

            Board.SelectedIndex = 0;
            Board.SelectionChanged += Board_SelectionChanged;

            vm.PropertyChanged += Vm_PropertyChanged;

            //HexGameboardViewModel ds = new HexGameboardViewModel();
            //Board.ItemsSource = ds.Terrain.Terrain;
        }

        private void Vm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(sender != null)
            {
                HexGameboardViewModel vm = (HexGameboardViewModel)sender;
                DataContext = vm;

                Board.ItemsSource = vm.Grid;
            }

            //this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () => {
                

            //    });
        }

        private void Board_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TerrainPoint? previous = e.RemovedItems.Count > 0 ? (TerrainPoint?)e.RemovedItems[0] : null;
            TerrainPoint? next = e.AddedItems.Count > 0 ? (TerrainPoint?)e.AddedItems[0] : null;

            if (previous != null && next != null)
            {
                HexArrayHelper hah = new HexArrayHelper();
                HexGameboardViewModel vm = (HexGameboardViewModel)DataContext;
                if (vm != null)
                {
                    vm.ChangeTerrain(next, TerrainType.ShallowWater);
                }

                //Board.InvalidateVisual();
                // This login constrains selection to a neighbor
                //if (hah.IsNeigbour(next.Point.Value, new IntSize(8, 6), previous.Point.Value) == true)
                //{
                //    Debug.WriteLine("Is neighbor");
                //}
                //else
                //{
                //    Board.SelectionChanged -= Board_SelectionChanged;
                //    Board.SelectedItem = previous;
                //    Board.SelectionChanged += Board_SelectionChanged;
                //}
            }
        }
    }
}
