using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Libreria_CRUD
{
    public interface IConexion
    {
        SQLiteAsyncConnection GetConnection();
    }
}
