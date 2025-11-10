using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_ticaret_proje.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderNullableNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usename",
                table: "Orders",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "SiparisNotu",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Orders",
                newName: "Usename");

            migrationBuilder.AlterColumn<string>(
                name: "SiparisNotu",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
