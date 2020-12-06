using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;

namespace WaoCellDominicana_ProyectoFinal_Ap1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data/WaoCellDominicana.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                NombreUsuario = "admin",
                Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                Nombres = "Manager",
                Correo = "Admin@admin.com"

            });

            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 1, Modelo = "Samsung Galaxy Note" });
            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 2, Modelo = "Samsung Galaxy S8" });
            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 3, Modelo = "Samsung Galaxy A" });

            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 4, Modelo = "iPhone Xs" });
            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 5, Modelo = "iPhone XR" });
            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 6, Modelo = "iPhone 7s" });

            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 7, Modelo = "Huawei Y9" });
            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 8, Modelo = "Huawei Mate" });
            modelBuilder.Entity<Modelos>().HasData(new Modelos { ModeloId = 9, Modelo = "Huawei Nova" });

            modelBuilder.Entity<Marcas>().HasData(new Marcas { MarcaId = 1, Marca = "Samsung" });
            modelBuilder.Entity<Marcas>().HasData(new Marcas { MarcaId = 2, Marca = "Apple" });
            modelBuilder.Entity<Marcas>().HasData(new Marcas { MarcaId = 3, Marca = "Huawei" });

        }
    }
}