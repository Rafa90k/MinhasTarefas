using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasTarefas.Migrations
{
    public partial class MinhasTarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarefasModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TarefasModels_Id",
                table: "TarefasModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosModels_Id",
                table: "UsuariosModels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarefasModels");

            migrationBuilder.DropTable(
                name: "UsuariosModels");
        }
    }
}
