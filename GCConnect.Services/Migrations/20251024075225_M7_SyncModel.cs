using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCConnect.Services.Migrations
{
    /// <inheritdoc />
    public partial class M7_SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Leaves_FromTo",
                table: "Leaves",
                sql: "[FromDate] <= [ToDate]");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Leaves_Status",
                table: "Leaves",
                sql: "[Status] IN (N'Approved', N'Pending')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Leaves_Type",
                table: "Leaves",
                sql: "[Type] IN (N'Paid', N'Unpaid', N'Sick')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Leaves_FromTo",
                table: "Leaves");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Leaves_Status",
                table: "Leaves");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Leaves_Type",
                table: "Leaves");
        }
    }
}
