using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDocumental.Infrastucture.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terceros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FechaCrea = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    FechaActualiza = table.Column<DateTime>(nullable: true),
                    Identificaion = table.Column<string>(maxLength: 20, nullable: false),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: true),
                    Correo = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terceros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Correspondencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FechaCrea = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    FechaActualiza = table.Column<DateTime>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Consecutivo = table.Column<string>(maxLength: 10, nullable: false),
                    Tipo = table.Column<string>(maxLength: 2, nullable: false),
                    UrlArvhivo = table.Column<string>(maxLength: 200, nullable: false),
                    RemitenteId = table.Column<Guid>(nullable: false),
                    DestinatarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Terceros_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Terceros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Terceros_RemitenteId",
                        column: x => x.RemitenteId,
                        principalTable: "Terceros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FechaCrea = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    FechaActualiza = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false),
                    Rol = table.Column<string>(maxLength: 20, nullable: false),
                    TerceroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Terceros_TerceroId",
                        column: x => x.TerceroId,
                        principalTable: "Terceros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_DestinatarioId",
                table: "Correspondencias",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_RemitenteId",
                table: "Correspondencias",
                column: "RemitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TerceroId",
                table: "Usuarios",
                column: "TerceroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correspondencias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Terceros");
        }
    }
}
