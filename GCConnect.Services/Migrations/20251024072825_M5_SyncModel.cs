using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCConnect.Services.Migrations
{
    /// <inheritdoc />
    public partial class M5_SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Teams: drop старото varbinary и създай rowversion
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Teams");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Teams",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            // TeamRoles: същото
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TeamRoles");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TeamRoles",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            // (ако има и други таблици, които минават от varbinary към rowversion – повтори шаблона)
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Teams: върни към varbinary(max)
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Teams");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Teams",
                type: "varbinary(max)",
                nullable: true);

            // TeamRoles: върни към varbinary(max)
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TeamRoles");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TeamRoles",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />


    }
}
