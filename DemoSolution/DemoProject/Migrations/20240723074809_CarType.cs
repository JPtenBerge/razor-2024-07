using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Update.Internal;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class CarType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarTypes",
                column: "Name",
                value: "Onbekend"
            );
            migrationBuilder.InsertData(
                table: "CarTypes",
                column: "Name",
                value: "Elektrisch"
            );
            migrationBuilder.InsertData(
                table: "CarTypes",
                column: "Name",
                value: "Diesel"
            );
            migrationBuilder.InsertData(
                table: "CarTypes",
                column: "Name",
                value: "Benzine"
            );
            migrationBuilder.InsertData(
                table: "CarTypes",
                column: "Name",
                value: "LPG"
            );
            migrationBuilder.InsertData(
                table: "CarTypes",
                column: "Name",
                value: "Waterstof"
            );
            migrationBuilder.Sql("UPDATE Cars SET TypeId = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeId",
                table: "Cars",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_TypeId",
                table: "Cars",
                column: "TypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_TypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);
        }
    }
}
