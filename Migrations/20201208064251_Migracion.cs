using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WaoCellDominicana_ProyectoFinal_Ap1.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModeloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Garantia = table.Column<decimal>(type: "TEXT", nullable: false),
                    ITBIs = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    NCF = table.Column<string>(type: "TEXT", nullable: true),
                    SubTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalITBIs = table.Column<decimal>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    EMail = table.Column<string>(type: "TEXT", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    NombreUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NCF = table.Column<float>(type: "REAL", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalles",
                columns: table => new
                {
                    ComprasDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Decripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Importe = table.Column<decimal>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalles", x => x.ComprasDetalleId);
                    table.ForeignKey(
                        name: "FK_ComprasDetalles_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    ITBIS = table.Column<decimal>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    PorcientoItbis = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Marca" },
                values: new object[] { 1, "Samsung" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Marca" },
                values: new object[] { 2, "Apple" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Marca" },
                values: new object[] { 3, "Huawei" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 1, "Samsung Galaxy Note" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 2, "Samsung Galaxy S8" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 3, "Samsung Galaxy A" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 4, "iPhone Xs" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 5, "iPhone XR" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 6, "iPhone 7s" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 7, "Huawei Y9" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 8, "Huawei Mate" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "ModeloId", "Modelo" },
                values: new object[] { 9, "Huawei Nova" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellidos", "Correo", "FechaCreacion", "NombreUsuario", "Nombres", "Password", "Telefono" },
                values: new object[] { 1, null, "Admin@admin.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "Manager", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_CompraId",
                table: "ComprasDetalles",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "ComprasDetalles");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
