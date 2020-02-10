using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial1.Entidades;
using Parcial1.DAL;
using System.Linq;
using System.Linq.Expressions;

namespace Parcial1.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulo articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Articulo.Add(articulo) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Articulo articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(articulo).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
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

        public static Articulo Buscar(int id)
        {
            Articulo articulo = new Articulo();
            Contexto db = new Contexto();

            try
            {
                articulo = db.Articulo.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulo;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Articulo articulo = new Articulo();
            Contexto db = new Contexto();

            try
            {
                var Eliminar = ArticulosBLL.Buscar(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
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

        public static List<Articulo> GetList(Expression<Func<Articulo, bool>> articulo)
        {
            List<Articulo> Lista = new List<Articulo>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Articulo.Where(articulo).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
