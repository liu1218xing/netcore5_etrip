using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class modify_area_Entity_0311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AreaId",
                table: "Areas",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AreaId",
                table: "Areas",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
