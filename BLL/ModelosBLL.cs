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
    public class ModelosBLL
    {
        public static List<Modelos> GetList(Expression<Func<Modelos, bool>> modelos)
        {
            List<Modelos> Lista = new List<Modelos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Modelos.Where(modelos).ToList();
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

        public static List<Modelos> GetModelos()
        {
            List<Modelos> Lista = new List<Modelos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Modelos.ToList();
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