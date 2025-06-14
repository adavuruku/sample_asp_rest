using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eclinic.api.Central
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    subdomain = table.Column<string>(type: "text", nullable: false),
                    org_token = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    logo = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    database_type = table.Column<string>(type: "text", nullable: false),
                    connection_string = table.Column<string>(type: "text", nullable: false),
                    database_name = table.Column<string>(type: "text", nullable: false),
                    organization_status = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
