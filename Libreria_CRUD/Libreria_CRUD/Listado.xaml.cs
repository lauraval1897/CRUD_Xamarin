using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;

namespace Libreria_CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado : ContentPage
    {
        private SQLiteAsyncConnection db;
        private ObservableCollection<Libros> TablaLibros;
        public Listado()
        {
            InitializeComponent();
            db = DependencyService.Get<IConexion>().GetConnection();
            db.CreateTableAsync<Libros>().Wait();
        }
        
        protected async override void OnAppearing()
        {
            var registros = await db.Table<Libros>().ToListAsync();
            TablaLibros = new ObservableCollection<Libros>(registros);
            VerLibros.ItemsSource = TablaLibros;
            base.OnAppearing();
        }

        private void VerLibros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var libro = (Libros)e.SelectedItem;
            var id = libro.Id.ToString();
            var nombre = libro.Nombre_Libro.ToString();
            var autor = libro.Autor.ToString();
            var cantidad = libro.Cantidad.ToString();
            var publicacion = libro.Año_Publicacion.ToString();
            int ident = Convert.ToInt32(id);
            int cantidadlib = Convert.ToInt32(cantidad);
            int publicacionlib = Convert.ToInt32(publicacion);
            try
            {
                Navigation.PushAsync(new Detalles(ident, nombre, autor, cantidadlib, publicacionlib));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}