using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API_.NET.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Workload = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Subjects_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Grade = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "EndDate", "Lastname", "Name", "PhoneNumber", "Registration", "StartDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kent", "Marta", "33225555", 1, new DateTime(2021, 11, 23, 17, 29, 49, 582, DateTimeKind.Local).AddTicks(9206) },
                    { 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Isabela", "Paula", "3354288", 2, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(1110) },
                    { 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Antonia", "Laura", "55668899", 3, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(1132) },
                    { 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria", "Luiza", "6565659", 4, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(1143) },
                    { 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Machado", "Lucas", "565685415", 5, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(1152) },
                    { 6, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alvares", "Pedro", "456454545", 6, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(1166) },
                    { 7, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "José", "Paulo", "9874512", 7, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(1174) }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "BirthDate", "EndDate", "Lastname", "Name", "PhoneNumber", "Register", "StartDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Oliveira", null, null, 1, new DateTime(2021, 11, 23, 17, 29, 49, 575, DateTimeKind.Local).AddTicks(9128) },
                    { 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Soares", null, null, 2, new DateTime(2021, 11, 23, 17, 29, 49, 576, DateTimeKind.Local).AddTicks(9079) },
                    { 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marconi", null, null, 3, new DateTime(2021, 11, 23, 17, 29, 49, 576, DateTimeKind.Local).AddTicks(9101) },
                    { 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Carvalho", null, null, 4, new DateTime(2021, 11, 23, 17, 29, 49, 576, DateTimeKind.Local).AddTicks(9104) },
                    { 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Montanha", null, null, 5, new DateTime(2021, 11, 23, 17, 29, 49, 576, DateTimeKind.Local).AddTicks(9105) }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { 1, 1, "Matemática", null, 1, 0 },
                    { 2, 3, "Matemática", null, 1, 0 },
                    { 3, 3, "Física", null, 2, 0 },
                    { 4, 1, "Português", null, 3, 0 },
                    { 5, 1, "Inglês", null, 4, 0 },
                    { 6, 2, "Inglês", null, 4, 0 },
                    { 7, 3, "Inglês", null, 4, 0 },
                    { 8, 1, "Programação", null, 5, 0 },
                    { 9, 2, "Programação", null, 5, 0 },
                    { 10, 3, "Programação", null, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { 2, 1, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4420) },
                    { 4, 5, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4444) },
                    { 2, 5, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4427) },
                    { 1, 5, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4417) },
                    { 7, 4, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4468) },
                    { 6, 4, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4459) },
                    { 5, 4, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4446) },
                    { 4, 4, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4438) },
                    { 1, 4, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4412) },
                    { 7, 3, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4466) },
                    { 5, 5, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4448) },
                    { 6, 3, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4455) },
                    { 7, 2, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4464) },
                    { 6, 2, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4453) },
                    { 3, 2, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4431) },
                    { 2, 2, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4421) },
                    { 1, 2, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(3666) },
                    { 7, 1, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4461) },
                    { 6, 1, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4451) },
                    { 4, 1, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4436) },
                    { 3, 1, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4429) },
                    { 3, 3, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4433) },
                    { 7, 5, null, null, new DateTime(2021, 11, 23, 17, 29, 49, 583, DateTimeKind.Local).AddTicks(4470) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PrerequisiteId",
                table: "Subjects",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
