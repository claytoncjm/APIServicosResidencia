using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIServicosResidencia.Migrations
{
    public partial class relacionamentotabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoSeguro_TipoSeguro_NomeServicoId1",
                table: "TipoSeguro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoSeguro",
                table: "TipoSeguro");

            migrationBuilder.DropIndex(
                name: "IX_TipoSeguro_NomeServicoId1",
                table: "TipoSeguro");

            migrationBuilder.DropColumn(
                name: "NomeSeguro",
                table: "TipoSeguro");

            migrationBuilder.DropColumn(
                name: "NomeServicoId1",
                table: "TipoSeguro");

            migrationBuilder.RenameTable(
                name: "TipoSeguro",
                newName: "NomeServicos");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCelular",
                table: "NomeClientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "LocalizacaCliente",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "LocalizacaCliente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NomeClienteId",
                table: "LocalizacaCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NomeClienteId",
                table: "NomeServicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeServicoRes",
                table: "NomeServicos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NomeServicos",
                table: "NomeServicos",
                column: "NomeServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_NomeServicos_NomeClienteId",
                table: "NomeServicos",
                column: "NomeClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_NomeServicos_NomeClientes_NomeClienteId",
                table: "NomeServicos",
                column: "NomeClienteId",
                principalTable: "NomeClientes",
                principalColumn: "NomeClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NomeServicos_NomeClientes_NomeClienteId",
                table: "NomeServicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NomeServicos",
                table: "NomeServicos");

            migrationBuilder.DropIndex(
                name: "IX_NomeServicos_NomeClienteId",
                table: "NomeServicos");

            migrationBuilder.DropColumn(
                name: "NomeClienteId",
                table: "LocalizacaCliente");

            migrationBuilder.DropColumn(
                name: "NomeClienteId",
                table: "NomeServicos");

            migrationBuilder.DropColumn(
                name: "NomeServicoRes",
                table: "NomeServicos");

            migrationBuilder.RenameTable(
                name: "NomeServicos",
                newName: "TipoSeguro");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCelular",
                table: "NomeClientes",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "LocalizacaCliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "LocalizacaCliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "NomeSeguro",
                table: "TipoSeguro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NomeServicoId1",
                table: "TipoSeguro",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoSeguro",
                table: "TipoSeguro",
                column: "NomeServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoSeguro_NomeServicoId1",
                table: "TipoSeguro",
                column: "NomeServicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoSeguro_TipoSeguro_NomeServicoId1",
                table: "TipoSeguro",
                column: "NomeServicoId1",
                principalTable: "TipoSeguro",
                principalColumn: "NomeServicoId");
        }
    }
}
