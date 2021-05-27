using System.Windows;
using System.Windows.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class spinner : UserControl
    {
        
        public spinner()
        {
            DataContext = this;
            InitializeComponent();
        }

        public double StrokeValue
        {
            get { return (double)GetValue(StrokeValueProperty); }
            set { SetValue(StrokeValueProperty, value); }
        }

        public static readonly DependencyProperty StrokeValueProperty =
            DependencyProperty.Register("StrokeValue", typeof(double), typeof(spinner)
            , new PropertyMetadata(0.0, new PropertyChangedCallback(OnStrokeValueChanged)));

        private static void OnStrokeValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as spinner).StrokeArray = new DoubleCollection { (double)e.NewValue, 100 };
        }


        public DoubleCollection StrokeArray
        {
            get { return (DoubleCollection)GetValue(StrokeArrayProperty); }
            set { SetValue(StrokeArrayProperty, value); }
        }

        public static readonly DependencyProperty StrokeArrayProperty =
            DependencyProperty.Register("StrokeArray", typeof(DoubleCollection), typeof(spinner)
            , new PropertyMetadata(new DoubleCollection { 0, 100 }));


        private void startAnim()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation(-50, 50, new Duration(TimeSpan.FromSeconds(5)));
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath(StrokeValueProperty));
            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            storyboard.DecelerationRatio = 0.2;
            storyboard.FillBehavior = FillBehavior.Stop;
            storyboard.BeginTime = TimeSpan.Zero;
            storyboard.AutoReverse = true;
            storyboard.SlipBehavior = SlipBehavior.Grow;
            storyboard.Begin();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            startAnim();
        }
    }

}
