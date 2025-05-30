using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidato_Competencia_CompetenciaId",
                table: "Candidato");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidato_Puesto_PuestoId",
                table: "Candidato");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiencia_Candidato_CandidatoIDCandidato",
                table: "Experiencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puesto",
                table: "Puesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiencia",
                table: "Experiencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competencia",
                table: "Competencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidato",
                table: "Candidato");

            migrationBuilder.RenameTable(
                name: "Puesto",
                newName: "Puestos");

            migrationBuilder.RenameTable(
                name: "Experiencia",
                newName: "Experiencias");

            migrationBuilder.RenameTable(
                name: "Competencia",
                newName: "Competencias");

            migrationBuilder.RenameTable(
                name: "Candidato",
                newName: "Candidatos");

            migrationBuilder.RenameIndex(
                name: "IX_Experiencia_CandidatoIDCandidato",
                table: "Experiencias",
                newName: "IX_Experiencias_CandidatoIDCandidato");

            migrationBuilder.RenameIndex(
                name: "IX_Candidato_PuestoId",
                table: "Candidatos",
                newName: "IX_Candidatos_PuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidato_CompetenciaId",
                table: "Candidatos",
                newName: "IX_Candidatos_CompetenciaId");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Puestos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puestos",
                table: "Puestos",
                column: "ID_Puesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiencias",
                table: "Experiencias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competencias",
                table: "Competencias",
                column: "ID_Competencia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidatos",
                table: "Candidatos",
                column: "IDCandidato");

            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarioMensual = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "ID_Puesto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Competencias_CompetenciaId",
                table: "Candidatos",
                column: "CompetenciaId",
                principalTable: "Competencias",
                principalColumn: "ID_Competencia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Puestos_PuestoId",
                table: "Candidatos",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "ID_Puesto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_Candidatos_CandidatoIDCandidato",
                table: "Experiencias",
                column: "CandidatoIDCandidato",
                principalTable: "Candidatos",
                principalColumn: "IDCandidato",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Competencias_CompetenciaId",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Puestos_PuestoId",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_Candidatos_CandidatoIDCandidato",
                table: "Experiencias");

            migrationBuilder.DropTable(
                name: "Capacitaciones");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puestos",
                table: "Puestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiencias",
                table: "Experiencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competencias",
                table: "Competencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidatos",
                table: "Candidatos");

            migrationBuilder.RenameTable(
                name: "Puestos",
                newName: "Puesto");

            migrationBuilder.RenameTable(
                name: "Experiencias",
                newName: "Experiencia");

            migrationBuilder.RenameTable(
                name: "Competencias",
                newName: "Competencia");

            migrationBuilder.RenameTable(
                name: "Candidatos",
                newName: "Candidato");

            migrationBuilder.RenameIndex(
                name: "IX_Experiencias_CandidatoIDCandidato",
                table: "Experiencia",
                newName: "IX_Experiencia_CandidatoIDCandidato");

            migrationBuilder.RenameIndex(
                name: "IX_Candidatos_PuestoId",
                table: "Candidato",
                newName: "IX_Candidato_PuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidatos_CompetenciaId",
                table: "Candidato",
                newName: "IX_Candidato_CompetenciaId");

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Puesto",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puesto",
                table: "Puesto",
                column: "ID_Puesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiencia",
                table: "Experiencia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competencia",
                table: "Competencia",
                column: "ID_Competencia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidato",
                table: "Candidato",
                column: "IDCandidato");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidato_Competencia_CompetenciaId",
                table: "Candidato",
                column: "CompetenciaId",
                principalTable: "Competencia",
                principalColumn: "ID_Competencia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidato_Puesto_PuestoId",
                table: "Candidato",
                column: "PuestoId",
                principalTable: "Puesto",
                principalColumn: "ID_Puesto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencia_Candidato_CandidatoIDCandidato",
                table: "Experiencia",
                column: "CandidatoIDCandidato",
                principalTable: "Candidato",
                principalColumn: "IDCandidato",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
