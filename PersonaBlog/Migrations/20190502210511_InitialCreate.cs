using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonaBlog.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Content = table.Column<string>(maxLength: 250, nullable: false),
                    AcceptRequest = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedRequests",
                columns: table => new
                {
                    AcceptedId = table.Column<Guid>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    RequestId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedRequests", x => x.AcceptedId);
                    table.ForeignKey(
                        name: "FK_AcceptedRequests_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedRequests_RequestId",
                table: "AcceptedRequests",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedRequests");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
