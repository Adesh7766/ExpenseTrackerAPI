using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTrackerAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Category");
        }
    }
}
