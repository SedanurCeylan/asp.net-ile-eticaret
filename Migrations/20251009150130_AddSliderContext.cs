using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_ticaret_proje.Migrations
{
    /// <inheritdoc />
    public partial class AddSliderContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliderlar",
                columns: new[] { "Id", "Aciklama", "Aktif", "Baslik", "Resim", "Sira" },
                values: new object[,]
                {
                    { 1, "Slider 1", true, "Slider 1 Başlık", "slider-1.jpeg", 0 },
                    { 2, "Slider 2", true, "Slider 2 Başlık", "slider-2.jpeg", 1 },
                    { 3, "Slider 3", true, "Slider 3 Başlık", "slider-3.jpeg", 2 },
                    { 4, "Slider 4", true, "Slider 4 Başlık", "slider-1.jpeg", 3 },
                    { 5, "Slider 5", true, "Slider 5 Başlık", "slider-2.jpeg", 4 },
                    { 6, "Slider 6", true, "Slider 6 Başlık", "slider-3.jpeg", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sliderlar",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
