using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "PasswordHash", "PasswordSalt", "Perfil", "Username", "longitude" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, new byte[] { 10, 30, 181, 10, 143, 224, 54, 15, 135, 107, 223, 1, 212, 192, 14, 115, 193, 38, 12, 22, 132, 149, 177, 17, 138, 140, 43, 132, 38, 227, 111, 251, 131, 129, 107, 65, 83, 149, 62, 178, 216, 235, 126, 102, 160, 86, 32, 148, 90, 204, 76, 32, 139, 94, 119, 183, 29, 69, 26, 197, 240, 200, 106, 65 }, new byte[] { 6, 56, 174, 232, 0, 200, 145, 39, 254, 0, 20, 138, 157, 6, 16, 142, 189, 83, 122, 27, 114, 135, 239, 186, 97, 109, 125, 183, 174, 85, 61, 198, 65, 189, 229, 184, 167, 84, 38, 113, 14, 44, 147, 33, 24, 20, 126, 192, 90, 151, 228, 103, 231, 245, 177, 12, 82, 0, 181, 129, 187, 13, 231, 118, 188, 244, 121, 19, 26, 197, 127, 121, 25, 235, 244, 35, 132, 225, 65, 16, 38, 81, 71, 46, 28, 44, 47, 30, 3, 141, 132, 36, 51, 250, 155, 15, 139, 135, 255, 195, 5, 194, 167, 23, 75, 14, 36, 42, 112, 107, 171, 6, 9, 123, 89, 129, 87, 124, 36, 100, 98, 165, 67, 62, 219, 59, 107, 86 }, "Admin", "UsuarioAmin", -46.596497999999997 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USUARIOS");
        }
    }
}
