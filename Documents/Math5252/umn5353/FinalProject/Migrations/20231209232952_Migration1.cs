using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tenor = table.Column<double>(type: "double precision", nullable: false),
                    rate = table.Column<double>(type: "double precision", nullable: false),
                    RateCurveId = table.Column<int>(type: "integer", nullable: false),
                    CurveName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_Curves_RateCurveId",
                        column: x => x.RateCurveId,
                        principalTable: "Curves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstSymbolId = table.Column<int>(type: "integer", nullable: false),
                    InstSymbolName = table.Column<string>(type: "text", nullable: false),
                    PriceNum = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Instruments_InstSymbolId",
                        column: x => x.InstSymbolId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    SymbolId = table.Column<int>(type: "integer", nullable: false),
                    SymbolName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_Instruments_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    units_obId = table.Column<int>(type: "integer", nullable: true),
                    Multiplier = table.Column<double>(type: "double precision", nullable: false),
                    ExchangeId = table.Column<int>(type: "integer", nullable: false),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    RateCurveId = table.Column<int>(type: "integer", nullable: false),
                    Curve = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_Curves_RateCurveId",
                        column: x => x.RateCurveId,
                        principalTable: "Curves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Markets_Exchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Markets_Units_units_obId",
                        column: x => x.units_obId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Underlyings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MarketId = table.Column<int>(type: "integer", nullable: false),
                    Market = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Underlyings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Underlyings_Instruments_Id",
                        column: x => x.Id,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Underlyings_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Derivatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MarketId = table.Column<int>(type: "integer", nullable: false),
                    Market = table.Column<string>(type: "text", nullable: false),
                    InstType = table.Column<string>(type: "text", nullable: false),
                    UnderlyingMonth = table.Column<int>(type: "integer", nullable: false),
                    UnderlyingYear = table.Column<int>(type: "integer", nullable: false),
                    UnderlyingId = table.Column<int>(type: "integer", nullable: false),
                    Underlying = table.Column<string>(type: "text", nullable: false),
                    Strike = table.Column<double>(type: "double precision", nullable: true),
                    Call_Put = table.Column<string>(type: "text", nullable: true),
                    Payout = table.Column<string>(type: "text", nullable: true),
                    BarrierType = table.Column<string>(type: "text", nullable: true),
                    BarrierLevel = table.Column<string>(type: "text", nullable: true),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derivatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Derivatives_Instruments_Id",
                        column: x => x.Id,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Derivatives_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Derivatives_Underlyings_UnderlyingId",
                        column: x => x.UnderlyingId,
                        principalTable: "Underlyings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Curves",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "US Treasury Curve" });

            migrationBuilder.InsertData(
                table: "Exchanges",
                columns: new[] { "Id", "Name", "ShortCode" },
                values: new object[] { 1, "Chicago Mercantile Exchange", "CME" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "Id", "Symbol" },
                values: new object[,]
                {
                    { 2, "CK2023" },
                    { 3, "CN2023" },
                    { 4, "CK2023" },
                    { 1, "CN2023" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bushels" },
                    { 2, "Gallons" }
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Curve", "Exchange", "ExchangeId", "Multiplier", "Name", "RateCurveId", "Size", "Symbol", "Unit", "UnitId", "units_obId" },
                values: new object[] { 1, "US Treasury Curve", "CME", 1, 100.0, "CBOT Corn", 1, 5000.0, "C", "Bushels", 1, null });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Date", "InstSymbolId", "InstSymbolName", "PriceNum" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "CN2023", 75.75 });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "CurveName", "RateCurveId", "Tenor", "rate" },
                values: new object[] { 1, "Treasury", 1, 3.0, 0.050000000000000003 });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "Date", "Price", "Quantity", "SymbolId", "SymbolName" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 30.0, 1.5, 1, "CH2023" });

            migrationBuilder.InsertData(
                table: "Underlyings",
                columns: new[] { "Id", "Expiration", "Market", "MarketId", "Month", "Year" },
                values: new object[] { 1, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "CBOT Corn", 1, 12, 2020 });

            migrationBuilder.InsertData(
                table: "Derivatives",
                columns: new[] { "Id", "BarrierLevel", "BarrierType", "Call_Put", "Expiration", "InstType", "Market", "MarketId", "Payout", "Strike", "Underlying", "UnderlyingId", "UnderlyingMonth", "UnderlyingYear" },
                values: new object[] { 2, null, null, "Call", new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "EuropeanOption", "CBOT Corn", 1, null, 740.0, "CN2023", 1, 12, 2023 });

            migrationBuilder.CreateIndex(
                name: "IX_Derivatives_MarketId",
                table: "Derivatives",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Derivatives_UnderlyingId",
                table: "Derivatives",
                column: "UnderlyingId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_ExchangeId",
                table: "Markets",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_RateCurveId",
                table: "Markets",
                column: "RateCurveId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_units_obId",
                table: "Markets",
                column: "units_obId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_InstSymbolId",
                table: "Prices",
                column: "InstSymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RateCurveId",
                table: "Rates",
                column: "RateCurveId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SymbolId",
                table: "Trades",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Underlyings_MarketId",
                table: "Underlyings",
                column: "MarketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Derivatives");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Underlyings");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Curves");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
