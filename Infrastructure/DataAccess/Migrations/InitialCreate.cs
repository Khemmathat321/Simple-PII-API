using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "users",
            table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(nullable: false),
                Email = table.Column<string>(nullable: false),
                PhoneNumber = table.Column<string>(nullable: true),
                Address = table.Column<string>(nullable: true),
            },
            constraints: table => { table.PrimaryKey("PK_Account", x => x.Id); });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("users");
    }
}
