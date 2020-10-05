 
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Diego_P1_AP1.Entidades;

namespace Diego_P1_AP1.UI.Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class rCiudades : Window
    {

        private Ciudad ciudad;

        public rCiudades()
        {
            InitializeComponent();
            ciudad = new Ciudad();
        }

    }
}

