using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeFeirasAPI.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Latitute = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Setcens = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AreaP = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CodDist = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CodSubPref = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SubPrefE = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Regiao5 = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Regiao8 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NomeFeira = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Registro = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feiras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feiras");
        }
    }
}
