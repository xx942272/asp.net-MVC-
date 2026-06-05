using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace s14112310482.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImgCarousels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgF = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgCarousels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<double>(type: "float", nullable: false),
                    ImgF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Memo", "Name" },
                values: new object[,]
                {
                    { 1, 1, "礦坑", "主世界" },
                    { 2, 2, "地獄", "下界" },
                    { 3, 3, "末地", "終界" }
                });

            migrationBuilder.InsertData(
                table: "ImgCarousels",
                columns: new[] { "Id", "ImgF" },
                values: new object[,]
                {
                    { 1, "a1.png" },
                    { 2, "a2.png" },
                    { 3, "a3.png" },
                    { 4, "a4.png" },
                    { 5, "a5.png" },
                    { 6, "a6.png" },
                    { 7, "a7.png" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "ImgF", "Name" },
                values: new object[,]
                {
                    { 1, 1, "遠古遺跡BOSS，潛藏危機與寶藏。", 7.0, "e1.png", "伏守者" },
                    { 2, 2, "烈焰燃燒，危機四伏的堡壘。", 5.0, "q1.png", "地獄堡壘" },
                    { 3, 3, "遺落空島，探索神秘終界城。", 9.0, "w1.png", "終界城" },
                    { 4, 1, "幽匿遺跡伏守危險寶庫", 9.0, "e2.png", "遠古城市" },
                    { 5, 1, "探秘考驗解謎奪寶生存", 7.0, "e3.png", "試煉密室" },
                    { 6, 1, "晶石洞穴探險挖礦尋寶", 7.0, "e4.png", "紫晶洞" },
                    { 7, 1, "高塔刷怪狩獵挑戰生存", 9.0, "e5.png", "試煉密室生怪塔" },
                    { 8, 2, "廢棄傳送門幽暗生存戰", 9.0, "q2.png", "廢棄傳送門" },
                    { 9, 2, "豬靈要塞危險尋寶挑戰", 6.0, "q3.png", "堡壘遺跡" },
                    { 10, 3, "終界入口激活冒險終章", 6.0, "w2.png", "終界傳送門" },
                    { 11, 3, "虛空島嶼龍巢巔峰決戰", 8.0, "w3.png", "終界" },
                    { 12, 3, "終界霸主黑翼終極龍戰", 10.0, "w4.png", "終界龍" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ImgCarousels");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
