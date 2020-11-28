using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace WaoCellDominicana_ProyectoFinal_Ap1.BLL
{
    public class ClientesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                esOk = contexto.Clientes.Any(e => e.ClienteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static bool Guardar(Clientes Cliente)
        {
             if (!Existe(Cliente.ClienteId))
                return Insertar(Cliente);
            else
                return Modificar(Cliente);
        }

        private static bool Insertar(Clientes Cliente)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                if (contexto.Clientes.Add(Cliente) != null) { esOk = (contexto.SaveChanges() > 0); }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static bool Modificar(Clientes Cliente)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Entry(Cliente).State = EntityState.Modified;
                esOk = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                var Cliente = contexto.Clientes.Find(id);
                if (Cliente != null)
                {
                    contexto.Clientes.Remove(Cliente);
                    esOk = (contexto.SaveChanges() > 0);
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
            return esOk;
        }

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes Cliente;
            try
            {
                Cliente = contexto.Clientes.Find(id);
                if (Cliente == null)
                {
                    MessageBox.Show("Este Cliente no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Cliente;
        }

        public static List<Clientes> GetList()
        {
            Contexto contexto = new Contexto();
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = contexto.Clientes.ToList();
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = contexto.Clientes.Where(criterio).ToList();
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