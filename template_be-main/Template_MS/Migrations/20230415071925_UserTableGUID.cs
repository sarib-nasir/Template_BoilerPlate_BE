using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template_MS.Migrations
{
    public partial class UserTableGUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<Guid>(
                name: "UserLoginId",
                table: "UserLogin",
                nullable: false,
                defaultValue: Guid.NewGuid());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLoginId",
                table: "UserLogin");

            
        }
    }
}
