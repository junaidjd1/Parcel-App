﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAdvantages.Migrations
{
    public partial class ModelCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    InsuranceWorth = table.Column<string>(nullable: true),
                    Dimension = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    FID = table.Column<int>(nullable: false),
                    FranchiseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.PID);
                    table.ForeignKey(
                        name: "FK_Parcels_Franchises_FranchiseID",
                        column: x => x.FranchiseID,
                        principalTable: "Franchises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deliveryservices",
                columns: table => new
                {
                    DSID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    DeliveryRoute = table.Column<string>(nullable: true),
                    PID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveryservices", x => x.DSID);
                    table.ForeignKey(
                        name: "FK_DeliveryServices_Parcels_PID",
                        column: x => x.PID,
                        principalTable: "Parcels",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveryservices_PID",
                table: "Deliveryservices",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_FranchiseID",
                table: "Parcels",
                column: "FranchiseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveryservices");

            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
