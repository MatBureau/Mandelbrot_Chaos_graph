using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using OxyPlot;
using OxyPlot.Series;

namespace Mandelbrot_Chaos_graph
{
    /// <summary>
    /// Logique d'interaction pour Bifurcation.xaml
    /// </summary>
    public partial class Bifurcation : Window
    {
        private SeriesCollection _seriesCollection;
        private PlotModel _plotModel;

        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set
            {
                _plotModel = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Bifurcation()
        {
            InitializeComponent();
            
            PlotModel = new PlotModel { Title = "Diagramme de Bifurcation" };

            DataContext = this;

            GenerateBifurcation();
        }

        public void GenerateBifurcation()
        {
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle, MarkerSize = 2 };

            const double rStart = 2.4;
            const double rEnd = 4.0;
            const int rSteps = 1000;
            const int xSteps = 200;
            const int skipSteps = 1000;

            double rStepSize = (rEnd - rStart) / rSteps;
            for (int rStep = 0; rStep <= rSteps; rStep++)
            {
                double r = rStart + rStep * rStepSize;
                double x = 0.5;

                // Iterate the function to reach a stable value of x
                for (int i = 0; i < skipSteps; i++)
                {
                    x = r * x * (1 - x);
                }

                // Record the stable values of x for this value of r
                for (int i = 0; i < xSteps; i++)
                {
                    x = r * x * (1 - x);
                    scatterSeries.Points.Add(new ScatterPoint(r, x));
                }
            }

            PlotModel.Series.Clear();
            PlotModel.Series.Add(scatterSeries);
            PlotModel.InvalidatePlot(true);
        }
    }
}
