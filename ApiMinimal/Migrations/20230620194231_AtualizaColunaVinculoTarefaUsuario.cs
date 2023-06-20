using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMinimal.Migrations
{
    public partial class AtualizaColunaVinculoTarefaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Tarefas",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                newName: "IX_Tarefas_usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioId",
                table: "Tarefas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Tarefas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_usuarioId",
                table: "Tarefas",
                newName: "IX_Tarefas_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id");
        }
    }
}
