using System;
using System.Collections.Generic;
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

namespace grafgry
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string code;
            List<Node> nodes = new List<Node>();
            List<Edge> edges = new List<Edge>();
            List<int> tokens = new List<int>(new int[]{ 4, 5, 6 });

            string startingPlayer = "A";

            Graph grafik = new Graph(nodes, edges, tokens, startingPlayer);

            grafik.GenerateGraph(startingPlayer);
            code = grafik.ToString();

            Code.Text = code;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string code;
            List<Node> nodes = new List<Node>();
            List<Edge> edges = new List<Edge>();
            List<int> tokens = new List<int>(new int[] { 4, 5, 6 });

            string startingPlayer = "A";

            Graph grafik = new Graph(nodes, edges, tokens, startingPlayer);

            grafik.GenerateGraph(startingPlayer);



            code = grafik.ToString();

            Code.Text = code;
        }
    }
}
