using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bikeShop.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proveedor = table.Column<int>(nullable: false),
                    FechaPedido = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Orden_Proveedor_Proveedor",
                        column: x => x.Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    correlativo = table.Column<int>(nullable: false),
                    Id_Orden = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantida = table.Column<int>(nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => new { x.correlativo, x.Id_Orden });
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Producto_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Producto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_Id_Orden",
                        column: x => x.Id_Orden,
                        principalTable: "Orden",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_CodigoProducto",
                table: "DetalleOrden",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_Id_Orden",
                table: "DetalleOrden",
                column: "Id_Orden");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Proveedor",
                table: "Orden",
                column: "Proveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
