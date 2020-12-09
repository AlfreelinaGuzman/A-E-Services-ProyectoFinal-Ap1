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
    public class ComprasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Compras.Any(e => e.CompraId == id);
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

        public static bool Guardar(Compras Compra)
        {
            return Insertar(Compra);
        }

        private static bool Insertar(Compras Compra)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (contexto.Compras.Add(Compra) != null) 
                {
                    
                    foreach (var item in Compra.Detalle)
                    {
                        Articulos articulo = ArticulosBLL.Buscar(item.ArticuloId);
                        
                        articulo.Cantidad += item.Cantidad;
                        ArticulosBLL.Guardar(articulo);
                    }
                    paso = (contexto.SaveChanges() > 0); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Compras Compra)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var Anterior = contexto.Compras.Find(Compra.CompraId);
                foreach (var item in Compra.Detalle)
                {
                    Articulos articulo = ArticulosBLL.Buscar(item.ArticuloId);
                    articulo.Cantidad -= item.Cantidad;
                    ArticulosBLL.Guardar(articulo);
                }
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalle Where TareaId={Compra.CompraId}");

                foreach (var item in Compra.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                foreach (var item in Compra.Detalle)
                {
                    Articulos articulo = ArticulosBLL.Buscar(item.ArticuloId);
                    articulo.Cantidad += item.Cantidad;
                    ArticulosBLL.Guardar(articulo);
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
                var Compra = contexto.Compras.Find(id);
                if (Compra != null)
                {
                    foreach (var item in Compra.Detalle)
                    {
                        Articulos articulo = ArticulosBLL.Buscar(item.ArticuloId);
                        articulo.Cantidad -= item.Cantidad;
                        ArticulosBLL.Guardar(articulo);
                    }
                    contexto.Compras.Remove(Compra);
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
        public static void AgregarArticulo(int articuloId, int cantidad)
        {
            try
            {
                Articulos Articulo = ArticulosBLL.Buscar(articuloId);
                Articulo.Cantidad += cantidad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //contexto.Dispose();
            }
        }

        public static void QuitarArticulo(int articuloId, int cantidad)
        {
            try
            {
                Articulos Articulo = ArticulosBLL.Buscar(articuloId);
                Articulo.Cantidad += cantidad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //contexto.Dispose();
            }
        }
        public static Compras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compras Compra = new Compras();
            try
            {
                Compra = contexto.Compras.Include(x => x.Detalle)
                    .Where(x => x.CompraId == id)
                    .SingleOrDefault();
                if (Compra == null)
                {
                    MessageBox.Show("Esta compra no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Compra;
        }

        

        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Compras> Lista = new List<Compras>();
            try
            {
                Lista = contexto.Compras.Where(criterio).ToList();
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