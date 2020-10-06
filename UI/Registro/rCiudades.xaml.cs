
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
           if (!Validar()){
               return;
           }
                
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

            var found  = CiudadBLL.Buscar(Convert.ToInt32(CiudadIdTextBox.Text));


            if (found != null){
                this.ciudad = found;
            }
               
            else
            {
                this.ciudad = new Ciudad();
                MessageBox.Show("No encontrado, por favor confirme que sea un id valido e intente de nuevo ","", MessageBoxButton.OK);
            }


            this.DataContext = this.ciudad;
        }

         private bool Validar()
        {
            bool Valido = true;
            if (CiudadIdTextBox.Text.Length == 0 )
            {
                Valido = false;
                MessageBox.Show("Introduzca un id e intente de nuevo", "Error al guardad", MessageBoxButton.OK);
            }
            if (NombreTextBox.Text.Length == 0)
            {
                Valido = false;
                MessageBox.Show("Introduzca un nombre e intente de nuevo", "Error al guardad", MessageBoxButton.OK);
            }
            if(CiudadBLL.Repetido(NombreTextBox.Text)){
                Valido = false;
                MessageBox.Show(" Esta ciudad ya existe, introduzca un nombre diferente e intente de nuevo", "Error al guardad", MessageBoxButton.OK);
            }

            
            return Valido;
        }

        private void NuevoButton_Click(object render, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object render, RoutedEventArgs e)
        {
            if (CiudadBLL.Eliminar(Convert.ToInt32(CiudadIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado con exito");
            }
            else
                 MessageBox.Show("No se pudo eliminar , por favor confirme que sea un id valido e intente de nuevo ","", MessageBoxButton.OK);

        }

        

    }
}

