using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace Libreria_CRUD
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public MainPage()
        {
            InitializeComponent();
            conexion = DependencyService.Get<IConexion>().GetConnection();
        }

        private void btnAgregarLibro_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreLibro.Text) && !string.IsNullOrEmpty(txtAutor.Text) && !string.IsNullOrEmpty(txtPublicacion.Text) && !string.IsNullOrEmpty(txtCantidad.Text))
            {
                var datos = new Libros { Nombre_Libro = txtNombreLibro.Text, Autor = txtAutor.Text, Año_Publicacion = Convert.ToInt32(txtPublicacion.Text), Cantidad = Convert.ToInt32(txtCantidad.Text) };
                conexion.InsertAsync(datos);
                txtNombreLibro.Text = "";
                txtAutor.Text = "";
                txtCantidad.Text = "";
                txtPublicacion.Text = "";
            }
        }

        async void btnVerLibros_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listado());
        }
    }
}
