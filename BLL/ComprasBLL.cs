using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;

namespace WaoCellDominicana_ProyectoFinal_Ap1.BLL
{
    public class ComprasBLL
    {
        public static bool Guardar(Compras compras)
        {
            if (!Existe(compras.CompraId))
                return Insertar(compras);
            else
               return Modificar(compras);
        }

        private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try{
                existe = contexto.Compras.Any(o => o.CompraId== id);
            }
            catch(Exception){
                throw;

            } finally{
                contexto.Dispose();
            }
            return existe;
        }
        
        private static bool Insertar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Compras.Add(compras);
                paso = contexto.SaveChanges() > 0;

                if (paso)
                {
                    foreach (var comprdetalle in compras.ComprasDetalles)
                    {

                        var articulo = ArticulosBLL.Buscar(comprdetalle.ArticuloId);

                        if(articulo != null){
                            articulo.Cantidad += comprdetalle.Cantidad;
                            ArticulosBLL.Modificar(articulo);
                        }

                       //Articulos articulo = ArticulosBLL.Buscar(articulo.ArticuloId);
                        
                       // articulo.Cantidad += articulo.Cantidad;
                      //  ArticulosBLL.Guardar(articulo);
                    }

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

        public static bool Modificar(Compras compras){
            bool Modificado = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalles Where CompraId={compras.CompraId}");
                foreach (var anterior in compras.ComprasDetalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                
                contexto.Entry(compras).State = EntityState.Modified;
                Modificado = (contexto.SaveChanges()>0);

                if (Modificado)
                {

                    foreach (var comprdetalle in compras.ComprasDetalles)
                    {
                        if(comprdetalle.Id == 0){
                            var articulo = ArticulosBLL.Buscar(comprdetalle.ArticuloId);

                            if(articulo != null){
                                articulo.Cantidad += comprdetalle.Cantidad;
                                ArticulosBLL.Modificar(articulo);
                            }
                        }
                    
                    }
                }
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Modificado;
        }

        public static bool Eliminar(int id){
            bool Eliminado = false;
            Contexto contexto = new Contexto();
            try{
                var compras = contexto.Compras.Find(id);
                contexto.Entry(compras).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges()>0;

                if (Eliminado)
                {
                    foreach (var comprdetalle in compras.ComprasDetalles)
                    {
                        var articulo = ArticulosBLL.Buscar(comprdetalle.ArticuloId);

                        if(articulo != null){
                            articulo.Cantidad -= comprdetalle.Cantidad;
                            ArticulosBLL.Modificar(articulo);
                        }
                    
                    }

                }
            }

            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Compras Buscar(int id){
            Compras compras;
            Contexto contexto = new Contexto();
            try{
                compras = contexto.Compras.Include(x => x.ComprasDetalles).Where(p => p.CompraId  == id).SingleOrDefault();
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return compras;
        }

   
    public static List <Compras> GetList()
     {
            List<Compras> Lista = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Compras.ToList();
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

        public static List<Compras> GetList(Expression<Func<Compras, bool>> compras)
        {
            List<Compras> Lista = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Compras.ToList();
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

  //  }

    }
}