﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMVC.Migrations
{
    /// <inheritdoc />
    public partial class MakeClientRequiredInOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_IdClient",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "IdClient",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_IdClient",
                table: "Orders",
                column: "IdClient",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_IdClient",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "IdClient",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_IdClient",
                table: "Orders",
                column: "IdClient",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
