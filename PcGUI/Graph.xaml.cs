using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using logicPC.Plotters;
using logicPC.Gestionnaires;
using System.Text.RegularExpressions;
using logicPC.Settings;
using System.Drawing;
using System.Globalization;
using System.IO;
using logicPC.CardData;
using System.ServiceModel.Channels;

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
            gestionnaire.DataNotifier += DatagridRefresh_needed;
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

            List<PointF> hashpoints = HashPlotter.Plot(gestionnaire.UserListsStorage[SelectionBox.SelectedValue as string].Cards, gestionnaire.UserListsStorage[SelectionBox.SelectedValue as string].QuantityCards, endNF, incNF, SettingsLogic.DepreciationFactor);
            List<PointF> powerDrawPoints = HashPlotter.PlotPowerCost(gestionnaire.UserListsStorage[SelectionBox.SelectedValue as string].Cards, gestionnaire.UserListsStorage[SelectionBox.SelectedValue as string].QuantityCards, endNF, incNF, SettingsLogic.powerInflationFactor);
            
            graphScreen.Children.Clear();
            PointF old = new(0,0);
            for (int i = 0; i < hashpoints.Count; i++)
            {
                old = new(i * 10, -10);
                await SetPoint(new(i * 10, 0), old, System.Windows.Media.Brushes.Black, 0);
            }
            for (int i = 0; i < hashpoints.Count; i++)
            {
                old = new(-10, i * 10);
                await SetPoint(new(0, i * 10), old, System.Windows.Media.Brushes.Black, 0);
            }
            foreach (PointF point in hashpoints)
            {
                await SetPoint(point, old, System.Windows.Media.Brushes.Red, incNF);
                old = point;
            }
            old = new(0, 0);
            foreach (PointF point in powerDrawPoints)
            {
                await SetPoint(point, old, System.Windows.Media.Brushes.Orange, incNF);
                old = point;
            }
        }
        private async Task SetPoint(PointF point, PointF old, System.Windows.Media.SolidColorBrush brush, float precisionDelay)
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

            await Task.Delay((int)(SettingsLogic.GraphAnimationDelay*precisionDelay));
            /*
            if (old.X != 0)
            {
                Line line = new();
                line.Stroke = brush;
                line.Y2 = point.X;
                line.X2 = point.Y;
                line.X1 = old.X;
                line.Y1 = old.Y;

                graphScreen.Children.Add(line);
                Canvas.SetLeft(line, point.X);
                Canvas.SetBottom(line, point.Y);
            }
            */
        }

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string graphDir = new(Directory.GetParent(Directory.GetParent(SettingsLogic.PATH).ToString()) + @"\captures\");
            try
            {
                if (!Directory.Exists(graphDir))
                    Directory.CreateDirectory(graphDir);

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

                if (File.Exists(graphDir + @"Graphe.png"))
                {
                    while (File.Exists($"{graphDir}{filename}({i}).png"))
                        i++;

                    filename = $"{filename}({i})";
                }
                using (var stm = File.Create(graphDir + filename + @".png"))
                {
                    enc.Save(stm);
                }
            }
            catch (UnauthorizedAccessException err)
            {
                MessageBox.Show($"L'application doit être executée en tant qu'administrateur pour accéder au dossier: \n{graphDir} !\n\nArguments de l'exception:\n{err}", "PcParted: UnauthorizedAccessException",MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }
        private void DatagridRefresh_needed<E>(object sender, E e)
        {
            string selected = new("");
            if (SelectionBox.SelectedValue is not null)
                selected = SelectionBox.SelectedValue.ToString();
            if (DGrid is not null)
            {
                DGrid.ItemsSource = null;
                DGrid.ItemsSource = gestionnaire.CardDataToDisplay;
            }
        }

        private void SelectionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshMe();
        }

        private void RefreshMe()
        {
            gestionnaire.ActiveKey = (string)SelectionBox.SelectedValue;
            gestionnaire.RefreshDataToDisplay((string)SelectionBox.SelectedValue);
            DatagridRefresh_needed(this, new string((string)SelectionBox.SelectedValue));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshMe();
        }
    }
}
