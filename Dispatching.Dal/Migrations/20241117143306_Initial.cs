using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dispatching.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "circuit_boards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    quality_control_result = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_circuit_boards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "history_events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "circuit_board_components",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    circuit_board_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_circuit_board_components", x => new { x.id, x.circuit_board_id });
                    table.ForeignKey(
                        name: "FK_circuit_board_components_circuit_boards_circuit_board_id",
                        column: x => x.circuit_board_id,
                        principalTable: "circuit_boards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_circuit_board_components_circuit_board_id",
                table: "circuit_board_components",
                column: "circuit_board_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "circuit_board_components");

            migrationBuilder.DropTable(
                name: "history_events");

            migrationBuilder.DropTable(
                name: "circuit_boards");
        }
    }
}
