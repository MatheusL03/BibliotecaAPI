using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LIVRO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomedoLivro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLivro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LIVRO", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_LIVRO",
                columns: new[] { "Id", "Autor", "DataLivro", "Disponibilidade", "Genero", "NomedoLivro", "preco" },
                values: new object[,]
                {
                    { 1, "Deus", "Desconhecido", true, "Livro Sagrado", "Bíblia", 50m },
                    { 2, "George Orwell", "1949", true, "Ficção política", "1984", 30m },
                    { 3, "Charlie Mackesy", "2020", true, "Animação", "O Menino, a Toupeira, a Raposa e o Cavalo", 60m },
                    { 4, "Charles Duhigg", "2012", true, "Livro de autoajuda", "O Poder do Hábito", 55m },
                    { 5, "Christian Barbosa", "2008", true, "Livro de autoajuda", "A tríade do tempo", 40m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LIVRO");
        }
    }
}
