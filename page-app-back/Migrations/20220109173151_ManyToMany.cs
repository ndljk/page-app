using Microsoft.EntityFrameworkCore.Migrations;

namespace page_app_back.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Status_StatusId",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statusi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statusi",
                table: "Statusi",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studenti_Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    KursId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti_Kursevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studenti_Kursevi_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studenti_Kursevi_Studenti_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Kursevi_KursId",
                table: "Studenti_Kursevi",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Kursevi_StudentId",
                table: "Studenti_Kursevi",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Statusi_StatusId",
                table: "Studenti",
                column: "StatusId",
                principalTable: "Statusi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Statusi_StatusId",
                table: "Studenti");

            migrationBuilder.DropTable(
                name: "Studenti_Kursevi");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statusi",
                table: "Statusi");

            migrationBuilder.RenameTable(
                name: "Statusi",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Status_StatusId",
                table: "Studenti",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
