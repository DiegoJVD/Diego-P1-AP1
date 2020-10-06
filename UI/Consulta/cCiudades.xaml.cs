using System;
using System.Windows;
using Diego_P1_AP1.DAL;
using Diego_P1_AP1.Entidades;
using Diego_P1_AP1.BLL;
using Diego_P1_AP1.UI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Diego_P1_AP1.UI.Consulta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class cCiudades : Window
    {
        public cCiudades()
        {
            InitializeComponent();
            
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            
             var listado = new List<Ciudad>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = CiudadBLL.GetList(e => e.CiudadId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1:    
                        listado = CiudadBLL.GetList(e => e.Nombre ==CriterioTextBox.Text);
                        break;
                    

                }
            }
            else
            {
                listado = CiudadBLL.GetList(c => true);
            }          

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        } 





    }
}