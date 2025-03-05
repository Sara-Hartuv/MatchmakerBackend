using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matchmakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceYear = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NumId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchmakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchmakers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    SubSector = table.Column<int>(type: "int", nullable: false),
                    GivesMoney = table.Column<int>(type: "int", nullable: false),
                    AskingMoney = table.Column<int>(type: "int", nullable: false),
                    CellPhone = table.Column<int>(type: "int", nullable: false),
                    Openness = table.Column<int>(type: "int", nullable: false),
                    ClothingStyle = table.Column<int>(type: "int", nullable: false),
                    License = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Physique = table.Column<int>(type: "int", nullable: false),
                    SkinTone = table.Column<int>(type: "int", nullable: false),
                    HairColor = table.Column<int>(type: "int", nullable: false),
                    LastStudy = table.Column<int>(type: "int", nullable: false),
                    StudyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    professionId = table.Column<int>(type: "int", nullable: false),
                    Workplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadCovering = table.Column<int>(type: "int", nullable: false),
                    Hat = table.Column<int>(type: "int", nullable: false),
                    Suit = table.Column<int>(type: "int", nullable: false),
                    Beard = table.Column<bool>(type: "bit", nullable: false),
                    Smoker = table.Column<bool>(type: "bit", nullable: false),
                    FamilyStyle = table.Column<int>(type: "int", nullable: false),
                    ParentalStatus = table.Column<int>(type: "int", nullable: false),
                    FamilyOpenness = table.Column<int>(type: "int", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameFromHome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionFind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NumId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_Professions_professionId",
                        column: x => x.professionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brothers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Married = table.Column<bool>(type: "bit", nullable: false),
                    NameIn_laws = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressIn_laws = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brothers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brothers_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidateGirl = table.Column<int>(type: "int", nullable: false),
                    IdCandidateGuy = table.Column<int>(type: "int", nullable: false),
                    IdMatchmaker = table.Column<int>(type: "int", nullable: false),
                    IsEngaged = table.Column<bool>(type: "bit", nullable: false),
                    DateMatch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Candidates_IdCandidateGirl",
                        column: x => x.IdCandidateGirl,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Histories_Candidates_IdCandidateGuy",
                        column: x => x.IdCandidateGuy,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Matchmakers_IdMatchmaker",
                        column: x => x.IdMatchmaker,
                        principalTable: "Matchmakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brothers_CandidateId",
                table: "Brothers",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CityId",
                table: "Candidates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_professionId",
                table: "Candidates",
                column: "professionId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_IdCandidateGirl",
                table: "Histories",
                column: "IdCandidateGirl");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_IdCandidateGuy",
                table: "Histories",
                column: "IdCandidateGuy");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_IdMatchmaker",
                table: "Histories",
                column: "IdMatchmaker");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CandidateId",
                table: "Inquiries",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchmakers_CityId",
                table: "Matchmakers",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brothers");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "Matchmakers");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
