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
using Diego_P1_AP1.UI.Consulta;
using Diego_P1_AP1.UI.Registro;

namespace Diego_P1_AP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

           public void rCiudadesMenuItem_CLick(object render, RoutedEventArgs e)
        {
            rCiudades registroCiudades = new rCiudades();
            registroCiudades.Show();
        }

            public void cCiudadesMenuItem_CLick(object render, RoutedEventArgs e)
        {
            cCiudades ConsultaCiudades = new cCiudades();
            ConsultaCiudades.Show();
        }
    }
}
