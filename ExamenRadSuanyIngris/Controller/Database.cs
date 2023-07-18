using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRadSuanyIngris.Controller
{
    public class Database
    {
        readonly SQLiteAsyncConnection _connection;

        public Database() { }

        public Database(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            // Creacion de objetos de base de datos
            _connection.CreateTableAsync<Model.ClassContactos>().Wait();
        }
        // Crear metodos CREATE - READ - UPDATE - DELETE

        public Task<int> AddContacto(Model.ClassContactos Contacto)
        {
            if (Contacto.Id == 0)
            {
                return _connection.InsertAsync(Contacto); 
                
            }
            else
            {
             return _connection.UpdateAsync(Contacto);
            }
        }
        public Task<List<Model.ClassContactos>> GetAllContacto()
        {
            return _connection.Table<Model.ClassContactos>().ToListAsync();
        }

        public Task<Model.ClassContactos> GetContacto(int pid)
        {
            return _connection.Table<Model.ClassContactos>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        public Task<int> DeletePersona(Model.ClassContactos Contacto)
        {
            return _connection.DeleteAsync(Contacto);
        }

    }
}
