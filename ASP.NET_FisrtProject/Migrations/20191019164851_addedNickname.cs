using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_FisrtProject.Migrations
{
    public partial class addedNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Contacts");
        }
    }
}
