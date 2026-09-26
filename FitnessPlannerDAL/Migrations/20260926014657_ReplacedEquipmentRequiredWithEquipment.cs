using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPlanner.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ReplacedEquipmentRequiredWithEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentRequired",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Exercises",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Exercises");

            migrationBuilder.AddColumn<bool>(
                name: "EquipmentRequired",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
