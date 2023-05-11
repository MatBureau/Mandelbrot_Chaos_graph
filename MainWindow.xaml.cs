using LiveCharts.Wpf;
using LiveCharts;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Mandelbrot_Chaos_graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _r;
        private double _x;
        private SeriesCollection _seriesCollection;

        public double R
        {
            get { return _r; }
            set
            {
                _r = value;
                OnPropertyChanged();
            }
        }

        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }
        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }
        public MainWindow()
        {
            InitializeComponent();


            R = 2;
            X = 0.5;

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = GenerateValues(R, X, 40)
                }
            };
        }

        private ChartValues<double> GenerateValues(double r, double x, int count)
        {
            var values = new ChartValues<double>();

            for (int i = 0; i < count; i++)
            {
                x = r * x * (1 - x);
                values.Add(x);
            }

            return values;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BTN_Fract_Click(object sender, RoutedEventArgs e)
        {
            Fractales fen_fract = new Fractales();
            fen_fract.Show();
        }

        ////Le graphique avec live charts (non optimal et mal rendu)
        //private void GenerateBifurcationDiagram(double rStart, double rEnd, int rSteps, int xSteps, int skipSteps)
        //{
        //    SeriesCollection = new SeriesCollection();

        //    double rStepSize = (rEnd - rStart) / rSteps;
        //    for (int rStep = 0; rStep <= rSteps; rStep++)
        //    {
        //        double r = rStart + rStep * rStepSize;
        //        double x = 0.5;

        //        // Itérer la fonction pour arriver à une valeur stable de x
        //        for (int i = 0; i < skipSteps; i++)
        //        {
        //            x = r * x * (1 - x);
        //        }

        //        // Enregistrer les valeurs stables de x pour cette valeur de r
        //        var values = new ChartValues<double>();
        //        for (int i = 0; i < xSteps; i++)
        //        {
        //            x = r * x * (1 - x);
        //            values.Add(x);
        //        }

        //        // Ajouter les valeurs à la collection de séries
        //        SeriesCollection.Add(new ScatterSeries
        //        {
        //            Values = values,
        //            PointGeometry = DefaultGeometries.Circle,
        //            Fill = Brushes.Black
        //        });
        //    }
        //}

       

        private void BifurcationButton_Click(object sender, RoutedEventArgs e)
        {
            //GenerateBifurcationDiagram(1, 4, 10, 10, 10);
            Bifurcation bif = new Bifurcation();
            bif.Show();
        }

        private void BTN_Sierpinski_Click(object sender, RoutedEventArgs e)
        {
            Sierpinski sp = new Sierpinski();
            sp.Show();
        }
    }
}
