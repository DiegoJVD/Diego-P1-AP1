
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Diego_P1_AP1.Entidades;
using Diego_P1_AP1.DAL;
using Diego_P1_AP1.BLL;
using Diego_P1_AP1.UI.Registro;

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

         private void BuscarButton_Click(object render, RoutedEventArgs e)
        {

            Context context = new Context();

            var found = CiudadBLL.Buscar(Convert.ToInt32(CiudadTextBox.Text));


            if (found != null)
               
            else
            {
                this.ciudad = new Ciudad();
                MessageBox.Show("No encontrado, por favor confirme que sea un id valido e intente de nuevo ","", MessageBoxButton.OK);
            }


            this.DataContext = this.ciudad;
        }

    }
}

