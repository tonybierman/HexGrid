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
            Board.ItemsSource =
                Enumerable.Range(0, Board.RowCount)
                    .SelectMany(r => Enumerable.Range(0, Board.ColumnCount)
                    .Select(c => new IntPoint(c, r)))
                    .ToList();

            Board.SelectedIndex = 0;
            Board.SelectionChanged += Board_SelectionChanged;
        }

        private void Board_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IntPoint? previous = e.RemovedItems.Count > 0 ? (IntPoint?)e.RemovedItems[0] : null;
            IntPoint? next = e.AddedItems.Count > 0 ? (IntPoint?)e.AddedItems[0] : null;

            if(previous != null && next != null)
            {
                HexArrayHelper hah = new HexArrayHelper();
                if (hah.IsNeigbour(next.Value, new IntSize(8, 6), previous.Value) == true)
                {
                    Debug.WriteLine("Is neighbor");
                }
                else
                {
                    Board.SelectionChanged -= Board_SelectionChanged;
                    Board.SelectedItem = previous;
                    Board.SelectionChanged += Board_SelectionChanged;
                }
            }
        }
    }
}
