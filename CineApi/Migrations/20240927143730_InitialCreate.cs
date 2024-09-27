using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaEntradas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaEntradas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaRegistro = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracion = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaEstreno = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    poster = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    tipoSala = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Filas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    salaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Filas_Salas_salaId",
                        column: x => x.salaId,
                        principalTable: "Salas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    peliculaId = table.Column<long>(type: "bigint", nullable: false),
                    salaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_salaId",
                        column: x => x.salaId,
                        principalTable: "Salas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Butacas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    disponible = table.Column<bool>(type: "bit", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Butacas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Butacas_Filas_filaId",
                        column: x => x.filaId,
                        principalTable: "Filas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteId = table.Column<long>(type: "bigint", nullable: false),
                    peliculaId = table.Column<long>(type: "bigint", nullable: false),
                    butacaId = table.Column<long>(type: "bigint", nullable: false),
                    categoriaEntradaId = table.Column<long>(type: "bigint", nullable: false),
                    Funcionid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Boletos_Butacas_butacaId",
                        column: x => x.butacaId,
                        principalTable: "Butacas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boletos_CategoriaEntradas_categoriaEntradaId",
                        column: x => x.categoriaEntradaId,
                        principalTable: "CategoriaEntradas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boletos_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boletos_Funciones_Funcionid",
                        column: x => x.Funcionid,
                        principalTable: "Funciones",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Boletos_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_butacaId",
                table: "Boletos",
                column: "butacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_categoriaEntradaId",
                table: "Boletos",
                column: "categoriaEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_clienteId",
                table: "Boletos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_Funcionid",
                table: "Boletos",
                column: "Funcionid");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_peliculaId",
                table: "Boletos",
                column: "peliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Butacas_filaId",
                table: "Butacas",
                column: "filaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_correo",
                table: "Clientes",
                column: "correo",
                unique: true,
                filter: "[correo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Filas_salaId",
                table: "Filas",
                column: "salaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_peliculaId",
                table: "Funciones",
                column: "peliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_salaId",
                table: "Funciones",
                column: "salaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_numero",
                table: "Salas",
                column: "numero",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletos");

            migrationBuilder.DropTable(
                name: "Butacas");

            migrationBuilder.DropTable(
                name: "CategoriaEntradas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Filas");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
