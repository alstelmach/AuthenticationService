using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infrastructure.Persistence.Read.Migrations
{
    public partial class CreatedRolePermissionAssignmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionRoleAssignments",
                schema: "UserRead",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRoleAssignments",
                schema: "UserRead");
        }
    }
}
