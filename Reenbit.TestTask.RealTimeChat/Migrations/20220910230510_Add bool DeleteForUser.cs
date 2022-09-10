using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reenbit.TestTask.RealTimeChat.Migrations
{
    public partial class AddboolDeleteForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeleteForUser",
                table: "Message",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteForUser",
                table: "Message");
        }
    }
}
