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

        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                init();

                // Busca la persona por ID
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("No se encontró la persona con ese ID");

                result = conn.Delete(person);
                mensaje = string.Format("Se ha eliminado {0} registro(s)", result);
            }
            catch (Exception ex)
            {
                mensaje = string.Format("Error: {0}", ex.Message);
            }
        }

        //ACTUALIZAR
        public void UpdatePerson(int id, string nuevoNombre)
        {
            int result = 0;
            try
            {
                init();

                // Busca la persona
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("No se encontró la persona con ese ID");

                if (string.IsNullOrEmpty(nuevoNombre))
                    throw new Exception("El nombre no puede estar vacío");

                // Actualiza y guarda
                person.Nombre = nuevoNombre;
                result = conn.Update(person);
                mensaje = string.Format("Se ha actualizado {0} registro(s)", result);
            }
            catch (Exception ex)
            {
                mensaje = string.Format("Error: {0}", ex.Message);
            }
        }
    }
}

    

