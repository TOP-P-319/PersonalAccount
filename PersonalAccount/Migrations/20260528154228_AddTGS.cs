using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class AddTGS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "student_profiles",
                newName: "id");

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

            migrationBuilder.CreateTable(
                name: "teacher_profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    account_id = table.Column<int>(type: "INTEGER", nullable: false),
                    full_name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    photo_url = table.Column<string>(type: "TEXT", maxLength: 2047, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_teacher_profiles_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_group_subjets",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    teacher_account_id = table.Column<int>(type: "INTEGER", nullable: false),
                    group_id = table.Column<int>(type: "INTEGER", nullable: false),
                    subject_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_group_subjets", x => x.id);
                    table.ForeignKey(
                        name: "FK_teacher_group_subjets_accounts_teacher_account_id",
                        column: x => x.teacher_account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_group_subjets_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_group_subjets_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teacher_group_subjets_group_id",
                table: "teacher_group_subjets",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_group_subjets_subject_id",
                table: "teacher_group_subjets",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_group_subjets_teacher_account_id",
                table: "teacher_group_subjets",
                column: "teacher_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_profiles_account_id",
                table: "teacher_profiles",
                column: "account_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacher_group_subjets");

            migrationBuilder.DropTable(
                name: "teacher_profiles");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "student_profiles",
                newName: "profile_id");
        }
    }
}
