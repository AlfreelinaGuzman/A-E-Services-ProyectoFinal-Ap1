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
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data/Databse.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                NombreUsuario = "admin",
                Contraseña = "1234",
                Nombres = "Manager",
                Correo = "Admin@admin.com"
                
            });
        }







      



        
    }
}