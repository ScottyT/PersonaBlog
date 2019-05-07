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
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Content = table.Column<string>(maxLength: 250, nullable: false),
                    AcceptRequest = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedRequests",
                columns: table => new
                {
                    AcceptedId = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    RequestID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedRequests", x => x.AcceptedId);
                    table.ForeignKey(
                        name: "FK_AcceptedRequests_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedRequests_RequestID",
                table: "AcceptedRequests",
                column: "RequestID");
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
