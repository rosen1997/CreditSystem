using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditS.Migrations
{
    public partial class DefaultUserCreditsOnCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Credits",
                table: "Users",
                nullable: false,
                defaultValue: 100f,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Credits",
                table: "Users",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldDefaultValue: 100f);
        }
    }
}
