using PuntosExtra.DAL;
using PuntosExtra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PuntosExtra.BLL
{
    public class PersonaBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Persona.Add(persona) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Persona.Find(id);
                db.Entry(eliminar).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas persona = new Personas();
            try
            {
                persona = db.Persona.Find(id);


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return persona;
        }

        public static List<Personas> GetLis(Expression<Func<Personas, bool>> personas)
        {
            List<Personas> lista = new List<Personas>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Persona.Where(personas).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
