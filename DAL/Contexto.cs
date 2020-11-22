using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using  WaoCellDominicana_ProyectoFinal_Ap1.Entidades;

namespace WaoCellDominicana_ProyectoFinal_Ap1.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data/Databse.db");
        }

      



        
    }
}