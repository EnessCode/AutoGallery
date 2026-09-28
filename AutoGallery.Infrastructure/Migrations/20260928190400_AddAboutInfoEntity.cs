using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutInfoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopTitle = table.Column<string>(type: "text", nullable: false),
                    Description1 = table.Column<string>(type: "text", nullable: false),
                    Description2 = table.Column<string>(type: "text", nullable: false),
                    Stat1Value = table.Column<string>(type: "text", nullable: false),
                    Stat1Text = table.Column<string>(type: "text", nullable: false),
                    Stat1Icon = table.Column<string>(type: "text", nullable: false),
                    Stat2Value = table.Column<string>(type: "text", nullable: false),
                    Stat2Text = table.Column<string>(type: "text", nullable: false),
                    Stat2Icon = table.Column<string>(type: "text", nullable: false),
                    Stat3Value = table.Column<string>(type: "text", nullable: false),
                    Stat3Text = table.Column<string>(type: "text", nullable: false),
                    Stat3Icon = table.Column<string>(type: "text", nullable: false),
                    Stat4Value = table.Column<string>(type: "text", nullable: false),
                    Stat4Text = table.Column<string>(type: "text", nullable: false),
                    Stat4Icon = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutInfos");
        }
    }
}
