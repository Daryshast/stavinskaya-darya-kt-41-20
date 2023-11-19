using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace stavinskaya_darya_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    direction_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор направления")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_direction_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование направления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_DirectionId", x => x.direction_id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование дисциплины"),
                    c_discipline_doesexist = table.Column<bool>(type: "bool", nullable: false, comment: "Существует ли дисциплина"),
                    DirectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_DisciplineId", x => x.discipline_id);
                    table.ForeignKey(
                        name: "fk_f_direction_id",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "direction_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_Discipline_fk_f_direction_id",
                table: "Discipline",
                column: "DirectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Directions");
        }
    }
}
