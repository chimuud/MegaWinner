using System;
using System.Collections.Generic;
using System.IO;
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

namespace MegaWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] lines;
        IDictionary<string, int> elem1 = new Dictionary<string, int>();
        IDictionary<string, int> elem2 = new Dictionary<string, int>();
        IDictionary<string, int> elem3 = new Dictionary<string, int>();
        IDictionary<string, int> elem4 = new Dictionary<string, int>();
        IDictionary<string, int> elem5 = new Dictionary<string, int>();
        IDictionary<string, int> elemb = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessWins();
            DisplayBig();
        }

        private void ProcessWins()
        {
            lines = File.ReadAllLines(@"WinResult.csv");
            foreach (string line in lines)
            {
                AddElem1(line);
                AddElem2(line);
                AddElem3(line);
                AddElem4(line);
                AddElem5(line);
            }
        }
        void DisplayBig()
        {
            var sortedElem1 = from entry in elem1 orderby entry.Value descending select entry;
            var sortedElem2 = from entry in elem2 orderby entry.Value descending select entry;
            var sortedElem3 = from entry in elem3 orderby entry.Value descending select entry;
            var sortedElem4 = from entry in elem4 orderby entry.Value descending select entry;
            var sortedElem5 = from entry in elem5 orderby entry.Value descending select entry;
            var sortedElemb = from entry in elemb orderby entry.Value descending select entry;
            grdElem1.ItemsSource = sortedElem1;
            grdElem2.ItemsSource = sortedElem2;
            grdElem3.ItemsSource = sortedElem3;
            grdElem4.ItemsSource = sortedElem4;
            grdElem5.ItemsSource = sortedElem5;
            grdElemb.ItemsSource = sortedElemb;
        }
        void AddIncrease(IDictionary<string, int> elem, string key)
        {
            if (elem.ContainsKey(key))
                elem[key]++;
            else
                elem.Add(key, 1);
        }
        void AddElem1(string line)
        {
            string[] elems = line.Split(',');
            for (int i = 1; i < 6; i++)
                AddIncrease(elem1, string.Concat('"', elems[i], '"'));
            AddIncrease(elemb, string.Concat('"', elems[6], '"'));
        }
        void AddElem2(string line)
        {
            string[] elems = line.Split(',');
            AddIncrease(elem2, string.Concat('"', elems[1], ',', elems[2], '"'));
            AddIncrease(elem2, string.Concat('"', elems[1], ',', elems[3], '"'));
            AddIncrease(elem2, string.Concat('"', elems[1], ',', elems[4], '"'));
            AddIncrease(elem2, string.Concat('"', elems[1], ',', elems[5], '"'));
            AddIncrease(elem2, string.Concat('"', elems[2], ',', elems[3], '"'));
            AddIncrease(elem2, string.Concat('"', elems[2], ',', elems[4], '"'));
            AddIncrease(elem2, string.Concat('"', elems[2], ',', elems[5], '"'));
            AddIncrease(elem2, string.Concat('"', elems[3], ',', elems[4], '"'));
            AddIncrease(elem2, string.Concat('"', elems[3], ',', elems[5], '"'));
            AddIncrease(elem2, string.Concat('"', elems[4], ',', elems[5], '"'));
        }
        void AddElem3(string line)
        {
            string[] elems = line.Split(',');
            AddIncrease(elem3, string.Concat('"', elems[1], ',', elems[2], ',', elems[3], '"'));
            AddIncrease(elem3, string.Concat('"', elems[1], ',', elems[2], ',', elems[4], '"'));
            AddIncrease(elem3, string.Concat('"', elems[1], ',', elems[2], ',', elems[5], '"'));
            AddIncrease(elem3, string.Concat('"', elems[1], ',', elems[3], ',', elems[4], '"'));
            AddIncrease(elem3, string.Concat('"', elems[1], ',', elems[3], ',', elems[5], '"'));
            AddIncrease(elem3, string.Concat('"', elems[1], ',', elems[4], ',', elems[5], '"'));
            AddIncrease(elem3, string.Concat('"', elems[2], ',', elems[3], ',', elems[4], '"'));
            AddIncrease(elem3, string.Concat('"', elems[2], ',', elems[3], ',', elems[5], '"'));
            AddIncrease(elem3, string.Concat('"', elems[2], ',', elems[4], ',', elems[5], '"'));
            AddIncrease(elem3, string.Concat('"', elems[3], ',', elems[4], ',', elems[5], '"'));
        }
        void AddElem4(string line)
        {
            string[] elems = line.Split(',');
            AddIncrease(elem4, string.Concat('"', elems[1], ',', elems[2], ',', elems[3], ',', elems[4], '"'));
            AddIncrease(elem4, string.Concat('"', elems[1], ',', elems[2], ',', elems[3], ',', elems[5], '"'));
            AddIncrease(elem4, string.Concat('"', elems[1], ',', elems[2], ',', elems[4], ',', elems[5], '"'));
            AddIncrease(elem4, string.Concat('"', elems[1], ',', elems[3], ',', elems[4], ',', elems[5], '"'));
            AddIncrease(elem4, string.Concat('"', elems[2], ',', elems[3], ',', elems[4], ',', elems[5], '"'));
        }
        void AddElem5(string line)
        {
            string[] elems = line.Split(',');
            AddIncrease(elem5, string.Concat('"', elems[1], ',', elems[2], ',', elems[3], ',', elems[4], ',', elems[5], '"'));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Top = 0;
            Height = System.Windows.SystemParameters.WorkArea.Height;
        }
    }
}
