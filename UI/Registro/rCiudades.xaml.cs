
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Diego_P1_AP1.Entidades;
using Diego_P1_AP1.DAL;
using Diego_P1_AP1.BLL;

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
            this.DataContext = this.ciudad;
        }

        public void GuardarButton_Click(object render, RoutedEventArgs e)
        {
           // if (!validar()){
           //     return;
           // }
                
            var paso = CiudadBLL.Guardar(ciudad);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con Exito","", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Error al guardar", "", MessageBoxButton.OK);
        }

        public void Limpiar()
        {
            this.ciudad = new Ciudad();
            this.DataContext = ciudad;
        }

    }
}

