﻿using System;
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

namespace PcParted
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public Graph()
        {
            DataContext = gestionnaire;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
