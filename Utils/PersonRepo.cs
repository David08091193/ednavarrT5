using ednavarrT5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ednavarrT5.Utils
{
    public class PersonRepo
    {
        string dbRuta;
        private SQLite.SQLiteConnection conn;
        public string mensaje { get; set; }

        public void init()
        {

            if (conn is not null)
                return;
            conn = new(dbRuta);
            conn.CreateTable<Models.Persona>();
        }

        public PersonRepo(string ruta)

        {
            dbRuta = ruta;


        }

        // CRUD

        public void AddNewPerson(string _nombre)
        {

            int result = 0;
            try
            {
                //Inserta persona

                init();
                if (string.IsNullOrEmpty(_nombre))
                    throw new Exception("El nombre no puede estar vacío");

                Persona person = new() { Nombre = _nombre };
                result = conn.Insert(person);
                mensaje = string.Format("Se ha insertado {0} registro(s)", result);
            }
            catch (Exception ex)
            {
                mensaje = string.Format("Error: {0}", ex.Message);


            }

        }   


        //Mostrar o listar
        public List<Persona> GetAllPersons()
        {
            try
            {
                init();
                return conn.Table<Persona>().ToList();
                mensaje = string.Format("Elementos listados correctamente");
            }
            catch (Exception ex)
            {
                mensaje = string.Format("Error: {0}", ex.Message);

            }

            return new List<Persona>();

        }


        //Eliminar


        //update


    }
}
