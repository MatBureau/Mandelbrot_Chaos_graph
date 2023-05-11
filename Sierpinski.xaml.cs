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
using System.Windows.Shapes;

namespace Mandelbrot_Chaos_graph
{
    /// <summary>
    /// Logique d'interaction pour Sierpinski.xaml
    /// </summary>
    public partial class Sierpinski : Window
    {
        public Sierpinski()
        {
            InitializeComponent();
            InitializeComponent();
            DrawSierpinskiTriangle(FractalCanvas, 0, 0, 500, 0, 250, 500, 10);
        }

        private void DrawSierpinskiTriangle(Canvas canvas, double x1, double y1, double x2, double y2, double x3, double y3, int depth)
        {
            if (depth == 0)
            {
                var polygon = new Polygon
                {
                    Points = new PointCollection { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) },
                    Stroke = Brushes.Black,
                    Fill = Brushes.Black,
                };
                canvas.Children.Add(polygon);
            }
            else
            {
                var x4 = (x1 + x2) / 2;
                var y4 = (y1 + y2) / 2;
                var x5 = (x2 + x3) / 2;
                var y5 = (y2 + y3) / 2;
                var x6 = (x1 + x3) / 2;
                var y6 = (y1 + y3) / 2;

                DrawSierpinskiTriangle(canvas, x1, y1, x4, y4, x6, y6, depth - 1);
                DrawSierpinskiTriangle(canvas, x4, y4, x2, y2, x5, y5, depth - 1);
                DrawSierpinskiTriangle(canvas, x6, y6, x5, y5, x3, y3, depth - 1);
            }
        }

        private void FractalCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Scale.ScaleX *= 1.1;
                Scale.ScaleY *= 1.1;
            }
            else
            {
                Scale.ScaleX /= 1.1;
                Scale.ScaleY /= 1.1;
            }
        }
    }
}
