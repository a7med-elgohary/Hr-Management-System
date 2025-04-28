using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_System.Migrations
{
    /// <inheritdoc />
    public partial class fixEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeId",
                table: "Users");

           

            migrationBuilder.AddColumn<long>(
                name: "UserAccountId",
                table: "Employees",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserAccountId",
                table: "Employees",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserAccountId",
                table: "Employees",
                column: "UserAccountId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserAccountId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserAccountId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Employees");

           

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true);
        }
    }
}
