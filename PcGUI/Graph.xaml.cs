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
using PcParted;
using logicPC;
using logicPC.Templates;
using logicPC.Plotters;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using System.Text.RegularExpressions;
using logicPC.Settings;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace PcParted
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public Graph()
        {
            DataContext = gestionnaire;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool wrong = false;
            if (!IsTextAllowed(incrementBox.Text))
            {
                incrementBox.BorderBrush = System.Windows.Media.Brushes.Red;
                wrong = true;
            }
            else
                incrementBox.BorderBrush = System.Windows.Media.Brushes.Gray;

            if (!IsTextAllowed(EndBox.Text))
            {
                EndBox.BorderBrush = System.Windows.Media.Brushes.Red;
                wrong = true;
            }
            else
                EndBox.BorderBrush = System.Windows.Media.Brushes.Gray;

            if (wrong) return;
                float.TryParse(EndBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture,out float endNF);
                float.TryParse(incrementBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture,out float incNF);

            List<PointF> hashpoints = HashPlotter.plot(gestionnaire.MesListesUtilisateur[SelectionBox.SelectedValue as string].Cards, gestionnaire.MesListesUtilisateur[SelectionBox.SelectedValue as string].QuantityCards, endNF, incNF, SettingsLogic.DepreciationFactor);
            List<PointF> powerDrawPoints = HashPlotter.plotPowerCost(gestionnaire.MesListesUtilisateur[SelectionBox.SelectedValue as string].Cards, gestionnaire.MesListesUtilisateur[SelectionBox.SelectedValue as string].QuantityCards, endNF, incNF, SettingsLogic.powerInflationFactor);
            
            graphScreen.Children.Clear();
            PointF old = new(0,0);
            foreach (PointF point in hashpoints)
            {
                await setPoint(point, old, System.Windows.Media.Brushes.Red);
                old = point;
            }
            old = new(0, 0);
            foreach (PointF point in powerDrawPoints)
            {
                await setPoint(point, old, System.Windows.Media.Brushes.Orange);
                old = point;
            }
        }
        private async Task setPoint(PointF point, PointF old, System.Windows.Media.SolidColorBrush brush)
        {
            Ellipse ellipse = new();
            ellipse.Height = 5;
            ellipse.Width = 5;
            ellipse.Fill = brush;
            ellipse.Stroke = brush;
            graphScreen.Children.Add(ellipse);
            if (point.Y > graphScreen.Height)
                Canvas.SetLeft(ellipse, graphScreen.Height);
            else
                Canvas.SetLeft(ellipse, point.Y);
            if (point.X > graphScreen.Width)
                Canvas.SetBottom(ellipse, graphScreen.Width);
            else
                Canvas.SetBottom(ellipse, point.X);

            await Task.Delay(SettingsLogic.GraphAnimationDelay);

            if (old.X != 0)
            {
                Line line = new();
                line.Stroke = brush;
                line.Y2 = point.X;
                line.X2 = point.Y;
                line.X1 = old.X;
                line.Y1 = old.Y;

                graphScreen.Children.Add(line);
                Canvas.SetLeft(line, old.Y);
                Canvas.SetBottom(line, old.X);
            }
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Size taille = new(graphScreen.ActualWidth, graphScreen.ActualHeight);
            var scale = 1;
            graphScreen.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
            var sz = graphScreen.RenderSize;
            var rect = new Rect(sz);
            var bmp = new RenderTargetBitmap((int)(scale * (rect.Width)),
                                             (int)(scale * (rect.Height)),
                                              scale * 96,
                                              scale * 96,
                                              PixelFormats.Default);
            bmp.Render(graphScreen);
            var enc = new PngBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bmp));

            string filename = @"Graphe";
            int i = 1;
            if (File.Exists(SettingsLogic.PATH + @"\Graphe.png"))
            {
                while (File.Exists($"{ SettingsLogic.PATH + @"\"}{filename}({i}).png"))
                    i++;

                filename = $"{filename}({i})";
            }
            using (var stm = File.Create(SettingsLogic.PATH+@"\"+filename+@".png"))
            {
                enc.Save(stm);
            }
        }
    }
}
