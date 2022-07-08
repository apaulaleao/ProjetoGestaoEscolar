using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    public partial class message2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aluno_turma_TurmaId",
                table: "aluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_turma",
                table: "turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_aluno",
                table: "aluno");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "aluno");

            migrationBuilder.RenameTable(
                name: "turma",
                newName: "Turma");

            migrationBuilder.RenameTable(
                name: "aluno",
                newName: "Aluno");

            migrationBuilder.RenameIndex(
                name: "IX_aluno_TurmaId",
                table: "Aluno",
                newName: "IX_Aluno_TurmaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turma",
                table: "Turma",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turma",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.RenameTable(
                name: "Turma",
                newName: "turma");

            migrationBuilder.RenameTable(
                name: "Aluno",
                newName: "aluno");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_TurmaId",
                table: "aluno",
                newName: "IX_aluno_TurmaId");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "aluno",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_turma",
                table: "turma",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_aluno",
                table: "aluno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_aluno_turma_TurmaId",
                table: "aluno",
                column: "TurmaId",
                principalTable: "turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
