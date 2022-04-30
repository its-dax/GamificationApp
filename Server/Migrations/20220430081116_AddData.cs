using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamificationApp.Server.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "A", "B", "C", "D", "GoodAnswer", "IsApproved", "SubjectId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "commit", "clone", "pull", "fetch", "C", false, 1, "Melyik git parancs okozhat merge conflictot?", 1 },
                    { 2, "Docker", "Azure cloud", "Git", "Jenkins", "B", false, 1, "Melyik nem alapvető DevOps eszköz?", 4 },
                    { 3, "Az alkalmazás működésének gyorsítása", "A fejlesztési folyamat gyorsítása", "Folyamatos integráció", "Folyamatos tesztelés", "A", true, 1, "Melyik nem egy alapvető DevOps előny?", 1 },
                    { 4, "A tesztelés automatizálása", "A deployment automatizálása", "Az integráció automatizálása", "A fejlesztés automatizálása", "D", true, 1, "Melyik nem alapvető feladata egy DevOps mérnöknek?", 1 },
                    { 5, "A forráskód változásának figyelése", "A forráskód futtatása", "A csapatmunka megkönnyítése", "A fejlesztés automatizálása", "B", true, 1, "Mire nem használható alapvetően a git?", 3 },
                    { 6, "git pull", "git reset", "git revert", "git status", "C", true, 1, "Melyik git parancs alapvető feladata egy commit által okozott változások visszaállítása? ", 2 },
                    { 7, "Google", "Microsoft", "Apple", "Amazon", "C", false, 2, "Melyik nem a három nagy felhőszolgáltató egyike?", 3 },
                    { 8, "Privát felhő", "Publikus felhő", "Hibrid felhő", "Statikus felhő", "D", true, 2, "Melyik nem egy felhő deployment modell?", 4 },
                    { 9, "Internet as Code", "Infrastructure as Code", "Infrastructure as Cloud", "Internet as Cloud", "B", true, 2, "Minek a rövidítése az IaC", 2 },
                    { 10, "5", "6", "7", "8", "C", true, 3, "Mi az eredménye a kövekező műveletnek?  3 + 4 ", 1 },
                    { 11, "15", "16", "17", "18", "A", true, 3, "Mi az eredménye a kövekező műveletnek?  11 + 4 ", 1 },
                    { 12, "27", "26", "25", "28", "A", true, 3, "Mi az eredménye a kövekező műveletnek?  13 + 14 ", 1 },
                    { 13, "7", "6", "5", "8", "D", true, 3, "Mi az eredménye a kövekező műveletnek?  6 + 2 ", 1 },
                    { 14, "7", "12", "5", "8", "B", false, 3, "Mi az eredménye a kövekező műveletnek?  6 x 2 ", 4 }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "Points", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { 1, 13, 1, 1 },
                    { 2, 5, 2, 1 },
                    { 3, 2, 3, 1 },
                    { 4, 6, 4, 1 },
                    { 5, 7, 5, 1 },
                    { 6, 16, 6, 1 },
                    { 7, 26, 7, 1 },
                    { 8, 6, 1, 2 },
                    { 9, 15, 2, 2 },
                    { 10, 0, 3, 2 },
                    { 11, 7, 4, 2 },
                    { 12, 12, 5, 2 },
                    { 13, 33, 6, 2 },
                    { 14, 8, 7, 2 },
                    { 15, 4, 1, 3 },
                    { 16, 11, 2, 3 },
                    { 17, 7, 3, 3 },
                    { 18, 27, 4, 3 },
                    { 19, 14, 5, 3 },
                    { 20, 36, 6, 3 },
                    { 21, 1, 7, 3 },
                    { 22, 2, 1, 4 },
                    { 23, 0, 2, 4 },
                    { 24, 14, 3, 4 },
                    { 25, 10, 4, 4 },
                    { 26, 14, 5, 4 },
                    { 27, 5, 6, 4 },
                    { 28, 33, 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "DevOps", 5 },
                    { 2, "Felhő technológiák", 5 },
                    { 3, "Matematika 1", 6 },
                    { 4, "Matematika 2", 6 },
                    { 5, "Diszkrét matematika", 6 },
                    { 6, "Számítógép hálózatok", 7 },
                    { 7, "Operációs rendszerek", 7 }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "NumberOfQuestions", "StartTime", "SubjectId", "TestTimeInMinutes" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 4, 30, 12, 50, 0, 0, DateTimeKind.Unspecified), 1, 60 },
                    { 2, 4, new DateTime(2022, 5, 10, 12, 50, 0, 0, DateTimeKind.Unspecified), 1, 60 },
                    { 3, 2, new DateTime(2022, 5, 10, 12, 50, 0, 0, DateTimeKind.Unspecified), 2, 60 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "M1DSSP", "Kovács Dávid", "M1DSSP", 0 },
                    { 2, "M2DSSP", "Szabó Éva", "M2DSSP", 0 },
                    { 3, "M3DSSP", "Felföldi András", "M3DSSP", 0 },
                    { 4, "M4DSSP", "Virág Kinga", "M4DSSP", 0 },
                    { 5, "ADMIN1", "Német Anna", "ADMIN1", 1 },
                    { 6, "ADMIN2", "Király András", "ADMIN2", 1 },
                    { 7, "ADMIN3", "Horváth Rebeka", "ADMIN3", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
