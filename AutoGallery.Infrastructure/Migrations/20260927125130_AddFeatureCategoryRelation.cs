using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFeatureCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "FeatureCategoryId",
                table: "Features",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FeatureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureCategoryId",
                table: "Features",
                column: "FeatureCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeatureCategories_FeatureCategoryId",
                table: "Features",
                column: "FeatureCategoryId",
                principalTable: "FeatureCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureCategories_FeatureCategoryId",
                table: "Features");

            migrationBuilder.DropTable(
                name: "FeatureCategories");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureCategoryId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureCategoryId",
                table: "Features");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Features",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
