using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class RemaneSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_group_subjets_subjects_subject_id",
                table: "teacher_group_subjets");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.RenameColumn(
                name: "subject_id",
                table: "teacher_group_subjets",
                newName: "discipline_id");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_group_subjets_subject_id",
                table: "teacher_group_subjets",
                newName: "IX_teacher_group_subjets_discipline_id");

            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplines", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_group_subjets_disciplines_discipline_id",
                table: "teacher_group_subjets",
                column: "discipline_id",
                principalTable: "disciplines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_group_subjets_disciplines_discipline_id",
                table: "teacher_group_subjets");

            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.RenameColumn(
                name: "discipline_id",
                table: "teacher_group_subjets",
                newName: "subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_group_subjets_discipline_id",
                table: "teacher_group_subjets",
                newName: "IX_teacher_group_subjets_subject_id");

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_group_subjets_subjects_subject_id",
                table: "teacher_group_subjets",
                column: "subject_id",
                principalTable: "subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
