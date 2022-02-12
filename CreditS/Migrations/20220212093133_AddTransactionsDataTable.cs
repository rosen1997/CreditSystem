using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditS.Migrations
{
    public partial class AddTransactionsDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionsData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendingUserId = table.Column<int>(nullable: false),
                    ReceivingUserId = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    WishMessage = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsData_Users_ReceivingUserId",
                        column: x => x.ReceivingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionsData_Users_SendingUserId",
                        column: x => x.SendingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsData_ReceivingUserId",
                table: "TransactionsData",
                column: "ReceivingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsData_SendingUserId",
                table: "TransactionsData",
                column: "SendingUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionsData");
        }
    }
}
