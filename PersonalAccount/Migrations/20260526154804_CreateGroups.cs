using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class CreateGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_accounts_account_id",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropColumn(
                name: "group_name",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "student_profiles");

            migrationBuilder.RenameIndex(
                name: "IX_students_account_id",
                table: "student_profiles",
                newName: "IX_student_profiles_account_id");

            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "student_profiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_student_profiles",
                table: "student_profiles",
                column: "profile_id");

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 2047, nullable: false),
                    photo_url = table.Column<string>(type: "TEXT", maxLength: 2047, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_profiles_group_id",
                table: "student_profiles",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_profiles_accounts_account_id",
                table: "student_profiles",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_profiles_groups_group_id",
                table: "student_profiles",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_profiles_accounts_account_id",
                table: "student_profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_student_profiles_groups_group_id",
                table: "student_profiles");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student_profiles",
                table: "student_profiles");

            migrationBuilder.DropIndex(
                name: "IX_student_profiles_group_id",
                table: "student_profiles");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "student_profiles");

            migrationBuilder.RenameTable(
                name: "student_profiles",
                newName: "students");

            migrationBuilder.RenameIndex(
                name: "IX_student_profiles_account_id",
                table: "students",
                newName: "IX_students_account_id");

            migrationBuilder.AddColumn<string>(
                name: "group_name",
                table: "students",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "profile_id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_accounts_account_id",
                table: "students",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
