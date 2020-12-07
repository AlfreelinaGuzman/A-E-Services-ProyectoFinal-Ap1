﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaoCellDominicana_ProyectoFinal_Ap1.DAL;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Decripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Garantia")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("NCF")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalITBIs")
                        .HasColumnType("TEXT");

                    b.HasKey("CompraId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.ComprasDetalles", b =>
                {
                    b.Property<int>("ComprasDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Decripcion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ITBIS")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Importe")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("ComprasDetalleId");

                    b.HasIndex("CompraId");

                    b.ToTable("ComprasDetalles");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Marcas", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            MarcaId = 1,
                            Marca = "Samsung"
                        },
                        new
                        {
                            MarcaId = 2,
                            Marca = "Apple"
                        },
                        new
                        {
                            MarcaId = 3,
                            Marca = "Huawei"
                        });
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Modelos", b =>
                {
                    b.Property<int>("ModeloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.HasKey("ModeloId");

                    b.ToTable("Modelos");

                    b.HasData(
                        new
                        {
                            ModeloId = 1,
                            Modelo = "Samsung Galaxy Note"
                        },
                        new
                        {
                            ModeloId = 2,
                            Modelo = "Samsung Galaxy S8"
                        },
                        new
                        {
                            ModeloId = 3,
                            Modelo = "Samsung Galaxy A"
                        },
                        new
                        {
                            ModeloId = 4,
                            Modelo = "iPhone Xs"
                        },
                        new
                        {
                            ModeloId = 5,
                            Modelo = "iPhone XR"
                        },
                        new
                        {
                            ModeloId = 6,
                            Modelo = "iPhone 7s"
                        },
                        new
                        {
                            ModeloId = 7,
                            Modelo = "Huawei Y9"
                        },
                        new
                        {
                            ModeloId = 8,
                            Modelo = "Huawei Mate"
                        },
                        new
                        {
                            ModeloId = 9,
                            Modelo = "Huawei Nova"
                        });
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Proveedores", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("EMail")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Correo = "Admin@admin.com",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NombreUsuario = "admin",
                            Nombres = "Manager",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"
                        });
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("NCF")
                        .HasColumnType("REAL");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("VentaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.VentasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ITBIS")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("VentasDetalle");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.ComprasDetalles", b =>
                {
                    b.HasOne("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Compras", null)
                        .WithMany("Detalle")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Ventas", b =>
                {
                    b.HasOne("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.VentasDetalle", b =>
                {
                    b.HasOne("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Ventas", null)
                        .WithMany("VentasDetalle")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Compras", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("WaoCellDominicana_ProyectoFinal_Ap1.Entidades.Ventas", b =>
                {
                    b.Navigation("VentasDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
