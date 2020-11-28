using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace WaoCellDominicana_ProyectoFinal_Ap1.BLL
{
    public class VentasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Ventas.Any(e => e.VentaId == id);
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

        public static bool Guardar(Ventas Venta)
        {
            return Insertar(Venta);
        }

        private static bool Insertar(Ventas Venta)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (contexto.Ventas.Add(Venta) != null) { paso = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(Ventas Venta)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalle Where TareaId={Venta.VentaId}");
                foreach (var item in Venta.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                paso = (contexto.SaveChanges() > 0);
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
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var Venta = contexto.Ventas.Find(id);
                if (Venta != null)
                {
                    contexto.Ventas.Remove(Venta);
                    paso = (contexto.SaveChanges() > 0);
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

        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas Venta = new Ventas();
            try
            {
                Venta = contexto.Ventas.Include(x => x.Detalle)
                    .Where(x => x.VentaId == id)
                    .SingleOrDefault();
                if (Venta == null)
                {
                    MessageBox.Show("Esta Venta no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Venta;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Ventas> Lista = new List<Ventas>();
            try
            {
                Lista = contexto.Ventas.Where(criterio).ToList();
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