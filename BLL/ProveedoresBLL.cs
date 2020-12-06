using System;
using System.Collections.Generic;
using System.Text;
using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace WaoCellDominicana_ProyectoFinal_Ap1.BLL
{
    public class ProveedoresBLL
    {
        public static bool Guardar(Proveedores proveedores)
        {
            if (!Existe(proveedores.ProveedorId))
                return Insertar(proveedores);
            else
                return Modificar(proveedores);
        }

        private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try
            {
                existe = contexto.Proveedores.Any(o => o.ProveedorId == id);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return existe;
        }

        private static bool Insertar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Proveedores.Add(proveedores);
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

        public static bool Modificar(Proveedores proveedores)
        {
            bool Modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(proveedores).State = EntityState.Modified;
                Modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            /* try{
                 contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenID = {suplidores.SuplidorID}");
                 foreach(var anterior in suplidores.OrdenesDetalle)
                 {
                     contexto.Entry(anterior).State =EntityState.Added;
                 }
                 contexto.Entry(suplidores).State = EntityState.Modified;
                 Modificado = (contexto.SaveChanges()>0);
             }
             catch(Exception){
                 throw;

             } finally{
                 contexto.Dispose();
             }*/

            return Modificado;
        }

        public static bool Eliminar(int id)
        {
            bool Eliminado = false;
            Contexto contexto = new Contexto();
            try
            {
                var proveedores = contexto.Proveedores.Find(id);
                contexto.Entry(proveedores).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges() > 0;
            }

            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Proveedores Buscar(int id)
        {
            Proveedores proveedores;
            Contexto contexto = new Contexto();
            try
            {
                proveedores = contexto.Proveedores.Find(id);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return proveedores;
        }

        public static List<Proveedores> GetList(Expression<Func<Proveedores, bool>> proveedores)
        {
            List<Proveedores> Lista = new List<Proveedores>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proveedores.Where(proveedores).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static List<Proveedores> GetList()
        {
            List<Proveedores> Lista = new List<Proveedores>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proveedores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

    }
}