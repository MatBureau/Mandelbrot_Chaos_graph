using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Logique d'interaction pour Fractales.xaml
    /// </summary>
    public partial class Fractales : Window
    {
        private WriteableBitmap bitmap;
        private double zoomLevel = 1.0;
        private double offsetX = 0.0;
        private double offsetY = 0.0;
        private Point lastMousePosition;

        public Fractales()
        {
            InitializeComponent();
        }

        private void DrawMandelbrot()
        {
            int width = (int)canvas.ActualWidth;
            int height = (int)canvas.ActualHeight;

            WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr32, null);

            byte[] pixels = new byte[width * height * 4];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Complex c = new Complex(
                        (x - width / 2.0) / (width / 4.0) * zoomLevel + offsetX,
                        (y - height / 2.0) / (height / 4.0) * zoomLevel + offsetY
                    );

                    Complex z = new Complex(0, 0);
                    int iterations = 0;

                    while (z.Magnitude <= 2.0 && iterations < 256)
                    {
                        z = z * z + c;
                        iterations++;
                    }

                    byte color = (byte)(iterations % 256);

                    int pixelOffset = (x + y * width) * 4;
                    pixels[pixelOffset] = color;
                    pixels[pixelOffset + 1] = color;
                    pixels[pixelOffset + 2] = color;
                    pixels[pixelOffset + 3] = 255;
                }
            }

            Int32Rect rect = new Int32Rect(0, 0, width, height);
            bitmap.WritePixels(rect, pixels, width * 4, 0);

            Image image = new Image();
            image.Source = bitmap;
            canvas.Children.Add(image);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bitmap = new WriteableBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96, 96, PixelFormats.Bgra32, null);
            image.Source = bitmap;

            DrawMandelbrot();
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lastMousePosition = e.GetPosition(canvas);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(canvas);
                offsetX += (position.X - lastMousePosition.X) / (canvas.ActualWidth / 4.0) * zoomLevel;
                offsetY += (position.Y - lastMousePosition.Y) / (canvas.ActualHeight / 4.0) * zoomLevel;
                lastMousePosition = position;
            }
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            zoomLevel *= e.Delta > 0 ? 1.50 : 0.9;
            DrawMandelbrot();
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DrawMandelbrot();
        }

    }
}
