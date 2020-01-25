using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace Libreria_CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalles : ContentPage
    {
        public int Id;
        private SQLiteAsyncConnection db;
        IEnumerable<Libros> RegistroDelete;
        IEnumerable<Libros> RegistroUpdate;
        public Detalles(int id, string nombre, string autor, int cant, int publ)
        {
            InitializeComponent();
            db = DependencyService.Get<IConexion>().GetConnection();
            Id = id;
            txtNombreLibro.Text = nombre;
            txtAutor.Text = autor;
            txtCantidad.Text = cant.ToString();
            txtPublicacion.Text = publ.ToString();
        }

        private static IEnumerable<Libros> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Libros>("Delete from Libros WHERE Id = ?", id);
        }

        private static IEnumerable<Libros> Update(SQLiteConnection dbs, string nombre, string autor, int cantidad, int año, int id)
        {
            return dbs.Query<Libros>("Update Libros SET Nombre_Libro = ?, Autor = ?, Cantidad = ?, Año_Publicacion = ?  WHERE Id = ?", nombre, autor, cantidad, año, id);
        }
        private void btnActuaizar_Clicked(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Libros.db3");
            var db = new SQLiteConnection(path);
            RegistroUpdate = Update(db, txtNombreLibro.Text, txtAutor.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPublicacion.Text), Id);
            Navigation.PopAsync();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Libros.db3");
            var db = new SQLiteConnection(path);
            RegistroDelete = Delete(db, Id);
            Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}