using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Libreria_CRUD.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConexionSQLite))]

namespace Libreria_CRUD.Droid
{
    class ConexionSQLite : IConexion
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documento = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var db = Path.Combine(documento, "Libros.db3");
            return new SQLiteAsyncConnection(db);
        }
    }
}