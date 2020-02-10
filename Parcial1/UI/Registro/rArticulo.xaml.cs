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
using Microsoft.EntityFrameworkCore;
using Parcial1.Entidades;
using Parcial1.BLL;
using Parcial1.DAL;
using System.Linq;
using System.Linq.Expressions;

namespace Parcial1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rArticulo.xaml
    /// </summary>
    public partial class rArticulo : Window
    {
        public rArticulo()
        {
            InitializeComponent();
            ProductoIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorInventarioTextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Articulo LlenaClase()
        {
            Articulo articulo = new Articulo();
            articulo.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulo.Costo = Convert.ToDecimal(CostoTextBox.Text);
            articulo.ValorInventario = (articulo.Existencia * articulo.Costo);

            return articulo;
        }

        private void LlenaCampo(Articulo articulo)
        {
            ProductoIdTextBox.Text = Convert.ToString(articulo.ProductoId);
            DescripcionTextBox.Text = articulo.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(articulo.Existencia);
            CostoTextBox.Text = Convert.ToString(articulo.Costo);
            ValorInventarioTextBox.Text = Convert.ToString(articulo.ValorInventario);
        }

        private bool Validar()
        {
            bool paso = true;

            if(string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MessageBox.Show("No Puede dejar Campos Vacíos");
                DescripcionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show("No Puede dejar Campos Vacíos");
                ExistenciaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show("No Puede dejar Campos Vacíos");
                CostoTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulo articulo = ArticulosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            return articulo != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulo articulo = new Articulo();
            bool paso = false;

            if (!Validar())
                return;

            articulo = LlenaClase();

            //determinar si es guardar o modificar
            if (ProductoIdTextBox.Text == "0")
                paso = ArticulosBLL.Guardar(articulo);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un Producto que no existe");
                    return;
                }
                paso = ArticulosBLL.Modificar(articulo);
            }

            //informar resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se pudo Guardar");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);

            Limpiar();

            if (ArticulosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar un producto que no existe");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Articulo articulo = new Articulo();
            int.TryParse(ProductoIdTextBox.Text, out id);

            Limpiar();

            articulo = ArticulosBLL.Buscar(id);

            if (articulo != null)
            {
                MessageBox.Show("Encontrado");
                LlenaCampo(articulo);
            }
            else
                MessageBox.Show("No existe");
        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorInventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void ValorInventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorInventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorInventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }
    }
}
