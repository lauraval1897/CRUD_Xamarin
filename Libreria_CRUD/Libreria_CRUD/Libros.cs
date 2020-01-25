using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Libreria_CRUD
{
    class Libros
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }
        public string Nombre_Libro { get; set; }
        public string Autor { get; set; }
        [MaxLength(4)]
        public int Año_Publicacion { get; set; }
        public int Cantidad { get; set; }
    }
}
