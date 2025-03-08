using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba_Kevin.Migrations
{
    /// <inheritdoc />
    public partial class AGREGADOMONTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Cuentas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Cuentas");
        }
    }
}
