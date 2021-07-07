using Microsoft.EntityFrameworkCore.Migrations;

namespace Unico.FeiraLivre.Persistence.Migrations.Application
{
    public partial class InitialcommitApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetCens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodSubPref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubPref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regiao05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regiao08 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFeira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feira", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feira");
        }
    }
}
