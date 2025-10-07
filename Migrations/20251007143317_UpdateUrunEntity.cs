using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_ticaret_proje.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrunEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { true, "1.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { true, "2.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 3,
                column: "Resim",
                value: "3.jpeg");

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { true, "4.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { true, "5.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                column: "Resim",
                value: "6.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 3,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Anasayfa", "Resim" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                column: "Resim",
                value: null);
        }
    }
}
