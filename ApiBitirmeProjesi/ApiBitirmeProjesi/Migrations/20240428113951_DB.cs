using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shippers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 738, DateTimeKind.Utc).AddTicks(2986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 738, DateTimeKind.Utc).AddTicks(1168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(9457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(9203),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(7369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(5633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(2265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(3779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(460));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shippers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(9451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 738, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(7679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 738, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(5974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(5734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(3984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(7369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(2265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(5633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 28, 11, 37, 38, 679, DateTimeKind.Utc).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 28, 11, 39, 51, 737, DateTimeKind.Utc).AddTicks(3779));
        }
    }
}
