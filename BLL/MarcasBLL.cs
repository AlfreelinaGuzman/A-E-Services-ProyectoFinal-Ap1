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
    public class MarcasBLL
    {
        public static List<Marcas> GetList(Expression<Func<Marcas, bool>> marcas)
        {
            List<Marcas> Lista = new List<Marcas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Marcas.Where(marcas).ToList();
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

        public static List<Marcas> GetMarcas()
        {
            List<Marcas> Lista = new List<Marcas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Marcas.ToList();
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