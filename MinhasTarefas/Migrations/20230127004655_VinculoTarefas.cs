using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasTarefas.Migrations
{
    public partial class VinculoTarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TarefasModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TarefasModels_UsuarioId",
                table: "TarefasModels",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefasModels_UsuariosModels_UsuarioId",
                table: "TarefasModels",
                column: "UsuarioId",
                principalTable: "UsuariosModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarefasModels_UsuariosModels_UsuarioId",
                table: "TarefasModels");

            migrationBuilder.DropIndex(
                name: "IX_TarefasModels_UsuarioId",
                table: "TarefasModels");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TarefasModels");
        }
    }
}
