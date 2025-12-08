using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormitoryComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddEditedAtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "Complaints",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "Complaints");
        }
    }
}
