﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sun.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageNameColumnforAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "abouts");
        }
    }
}
