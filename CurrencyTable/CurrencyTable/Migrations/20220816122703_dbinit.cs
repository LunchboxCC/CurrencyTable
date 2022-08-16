using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyTable.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    varchar20 = table.Column<string>(name: "varchar(20)", type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "varchar(3)", nullable: false),
                    Country = table.Column<string>(type: "varchar(80)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Move = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<short>(type: "smallint", nullable: false),
                    ValBuy = table.Column<double>(type: "float", nullable: false),
                    ValSell = table.Column<double>(type: "float", nullable: false),
                    ValMid = table.Column<double>(type: "float", nullable: false),
                    CurrBuy = table.Column<double>(type: "float", nullable: false),
                    CurrSell = table.Column<double>(type: "float", nullable: false),
                    CurrMid = table.Column<double>(type: "float", nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false),
                    CnbMid = table.Column<double>(type: "float", nullable: false),
                    EcbMid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
