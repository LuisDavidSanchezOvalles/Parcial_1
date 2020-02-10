using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Parcial1.Entidades;
using Parcial1.BLL;
using Parcial1.DAL;
using System.Linq;
using System.Linq.Expressions;

namespace Parcial1.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cArticulo.xaml
    /// </summary>
    public partial class cArticulo : Window
    {
        public cArticulo()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Articulo>();

            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch(FiltroComboBox.SelectedIndex)
                {
                    //todo
                    case 0:
                        Listado = ArticulosBLL.GetList(a => true);
                        break;
                    //Id
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        Listado = ArticulosBLL.GetList(a => a.ProductoId == id);
                        break;
                    //nombre
                    case 2:
                        Listado = ArticulosBLL.GetList(a => a.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                Listado = ArticulosBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
