using Diego_P1_AP1.DAL;
using Diego_P1_AP1.BLL;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Diego_P1_AP1.Entidades;

namespace Diego_P1_AP1.BLL
{
    public class CiudadBLL
    {
        public static bool Guardar(Ciudad ciudad)
        {
            if (!Existe(ciudad.CiudadId) && !Repetido(ciudad.Nombre))
                return Insertar(ciudad);
            else
                return Modificar(ciudad);
        }
        private static bool Insertar(Ciudad ciudad)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Ciudad.Add(ciudad);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Ciudad ciudad)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Entry(ciudad).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Context contexto = new Context();
            try
            {
        
                var ciudad = contexto.Ciudad.Find(id);

                if (ciudad != null)
                {
                    contexto.Ciudad.Remove(ciudad);//remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ciudad Buscar(int id)
        {
            Context contexto = new Context();
            Ciudad ciudad;

            try
            {
                ciudad = contexto.Ciudad.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ciudad;
        }

        public static List<Ciudad> GetList(Expression<Func<Ciudad, bool>> criterio)
        {
            List<Ciudad> lista = new List<Ciudad>();
            Context contexto = new Context();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.Ciudad.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Context contexto = new Context();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ciudad.Any(e => e.CiudadId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Repetido(string nombre)
        {
            Context contexto = new Context();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ciudad.Any(e => e.Nombre.Equals(nombre));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Ciudad> GetCiudad()
        {
            List<Ciudad> lista = new List<Ciudad>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Ciudad.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}