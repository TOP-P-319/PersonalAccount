using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class NewRoleSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_confirmation_tokens_students_student_id",
                table: "confirmation_tokens");

            migrationBuilder.DropIndex(
                name: "IX_students_email",
                table: "students");

            migrationBuilder.DropColumn(
                name: "email",
                table: "students");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "students",
                newName: "profile_id");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "confirmation_tokens",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_confirmation_tokens_student_id",
                table: "confirmation_tokens",
                newName: "IX_confirmation_tokens_account_id");

            migrationBuilder.AddColumn<int>(
                name: "account_id",
                table: "students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_account_id",
                table: "students",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_email",
                table: "accounts",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_confirmation_tokens_accounts_account_id",
                table: "confirmation_tokens",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_accounts_account_id",
                table: "students",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_confirmation_tokens_accounts_account_id",
                table: "confirmation_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_students_accounts_account_id",
                table: "students");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropIndex(
                name: "IX_students_account_id",
                table: "students");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "students",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "confirmation_tokens",
                newName: "student_id");

            migrationBuilder.RenameIndex(
                name: "IX_confirmation_tokens_account_id",
                table: "confirmation_tokens",
                newName: "IX_confirmation_tokens_student_id");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "students",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_students_email",
                table: "students",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_confirmation_tokens_students_student_id",
                table: "confirmation_tokens",
                column: "student_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
