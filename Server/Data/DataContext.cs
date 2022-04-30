using GamificationApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            //           //
            // User data //
            //           //

            model.Entity<User>().HasData(new User
            {
                Id = 1,
                Code = "M1DSSP",
                Name = "Kovács Dávid",
                Password = "M1DSSP",
                Role = 0
            });
            model.Entity<User>().HasData(new User
            {
                Id = 2,
                Code = "M2DSSP",
                Name = "Szabó Éva",
                Password = "M2DSSP",
                Role = 0
            });
            model.Entity<User>().HasData(new User
            {
                Id = 3,
                Code = "M3DSSP",
                Name = "Felföldi András",
                Password = "M3DSSP",
                Role = 0
            });
            model.Entity<User>().HasData(new User
            {
                Id = 4,
                Code = "M4DSSP",
                Name = "Virág Kinga",
                Password = "M4DSSP",
                Role = 0
            });
            model.Entity<User>().HasData(new User
            {
                Id = 5,
                Code = "ADMIN1",
                Name = "Német Anna",
                Password = "ADMIN1",
                Role = (User.Roles) 1
            });
            model.Entity<User>().HasData(new User
            {
                Id = 6,
                Code = "ADMIN2",
                Name = "Király András",
                Password = "ADMIN2",
                Role = (User.Roles) 1
            });
            model.Entity<User>().HasData(new User
            {
                Id = 7,
                Code = "ADMIN3",
                Name = "Horváth Rebeka",
                Password = "ADMIN3",
                Role = (User.Roles) 1
            });

            //              //        
            // Subject Data //
            //              //

            model.Entity<Subject>().HasData(new Subject
            {
                Id = 1,
                UserId = 5,
                Name = "DevOps"
            });
            model.Entity<Subject>().HasData(new Subject
            {
                Id = 2,
                UserId = 5,
                Name = "Felhő technológiák"
            });
            model.Entity<Subject>().HasData(new Subject
            {
                Id = 3,
                UserId = 6,
                Name = "Matematika 1"
            });
            model.Entity<Subject>().HasData(new Subject
            {
                Id = 4,
                UserId = 6,
                Name = "Matematika 2"
            });
            model.Entity<Subject>().HasData(new Subject
            {
                Id = 5,
                UserId = 6,
                Name = "Diszkrét matematika"
            });
            model.Entity<Subject>().HasData(new Subject
            {
                Id = 6,
                UserId = 7,
                Name = "Számítógép hálózatok"
            });
            model.Entity<Subject>().HasData(new Subject
            {
                Id = 7,
                UserId = 7,
                Name = "Operációs rendszerek"
            });

            //                //
            // Questions data //
            //                //

            model.Entity<Question>().HasData(new Question
            {
                Id = 1,
                UserId = 1,
                SubjectId = 1,
                Title = "Melyik git parancs okozhat merge conflictot?",
                A = "commit",
                B = "clone",
                C = "pull",
                D = "fetch",
                GoodAnswer = "C",
                IsApproved = false
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 2,
                UserId = 4,
                SubjectId = 1,
                Title = "Melyik nem alapvető DevOps eszköz?",
                A = "Docker",
                B = "Azure cloud",
                C = "Git",
                D = "Jenkins",
                GoodAnswer = "B",
                IsApproved = false
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 3,
                UserId = 1,
                SubjectId = 1,
                Title = "Melyik nem egy alapvető DevOps előny?",
                A = "Az alkalmazás működésének gyorsítása",
                B = "A fejlesztési folyamat gyorsítása",
                C = "Folyamatos integráció",
                D = "Folyamatos tesztelés",
                GoodAnswer = "A",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 4,
                UserId = 1,
                SubjectId = 1,
                Title = "Melyik nem alapvető feladata egy DevOps mérnöknek?",
                A = "A tesztelés automatizálása",
                B = "A deployment automatizálása",
                C = "Az integráció automatizálása",
                D = "A fejlesztés automatizálása",
                GoodAnswer = "D",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 5,
                UserId = 3,
                SubjectId = 1,
                Title = "Mire nem használható alapvetően a git?",
                A = "A forráskód változásának figyelése",
                B = "A forráskód futtatása",
                C = "A csapatmunka megkönnyítése",
                D = "A fejlesztés automatizálása",
                GoodAnswer = "B",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 6,
                UserId = 2,
                SubjectId = 1,
                Title = "Melyik git parancs alapvető feladata egy commit által okozott változások visszaállítása? ",
                A = "git pull",
                B = "git reset",
                C = "git revert",
                D = "git status",
                GoodAnswer = "C",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 7,
                UserId = 3,
                SubjectId = 2,
                Title = "Melyik nem a három nagy felhőszolgáltató egyike?",
                A = "Google",
                B = "Microsoft",
                C = "Apple",
                D = "Amazon",
                GoodAnswer = "C",
                IsApproved = false
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 8,
                UserId = 4,
                SubjectId = 2,
                Title = "Melyik nem egy felhő deployment modell?",
                A = "Privát felhő",
                B = "Publikus felhő",
                C = "Hibrid felhő",
                D = "Statikus felhő",
                GoodAnswer = "D",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 9,
                UserId = 2,
                SubjectId = 2,
                Title = "Minek a rövidítése az IaC",
                A = "Internet as Code",
                B = "Infrastructure as Code",
                C = "Infrastructure as Cloud",
                D = "Internet as Cloud",
                GoodAnswer = "B",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 10,
                UserId = 1,
                SubjectId = 3,
                Title = "Mi az eredménye a kövekező műveletnek?  3 + 4 ",
                A = "5",
                B = "6",
                C = "7",
                D = "8",
                GoodAnswer = "C",
                IsApproved = true
            }); 
            model.Entity<Question>().HasData(new Question
            {
                Id = 11,
                UserId = 1,
                SubjectId = 3,
                Title = "Mi az eredménye a kövekező műveletnek?  11 + 4 ",
                A = "15",
                B = "16",
                C = "17",
                D = "18",
                GoodAnswer = "A",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 12,
                UserId = 1,
                SubjectId = 3,
                Title = "Mi az eredménye a kövekező műveletnek?  13 + 14 ",
                A = "27",
                B = "26",
                C = "25",
                D = "28",
                GoodAnswer = "A",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 13,
                UserId = 1,
                SubjectId = 3,
                Title = "Mi az eredménye a kövekező műveletnek?  6 + 2 ",
                A = "7",
                B = "6",
                C = "5",
                D = "8",
                GoodAnswer = "D",
                IsApproved = true
            });
            model.Entity<Question>().HasData(new Question
            {
                Id = 14,
                UserId = 4,
                SubjectId = 3,
                Title = "Mi az eredménye a kövekező műveletnek?  6 x 2 ",
                A = "7",
                B = "12",
                C = "5",
                D = "8",
                GoodAnswer = "B",
                IsApproved = false
            });

            //            //
            // Score data //
            //            //

            // User1

            model.Entity<Score>().HasData(new Score
            {
                Id = 1,
                UserId = 1,
                SubjectId = 1,
                Points = 13
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 2,
                UserId = 1,
                SubjectId = 2,
                Points = 5
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 3,
                UserId = 1,
                SubjectId = 3,
                Points = 2
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 4,
                UserId = 1,
                SubjectId = 4,
                Points = 6
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 5,
                UserId = 1,
                SubjectId = 5,
                Points = 7
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 6,
                UserId = 1,
                SubjectId = 6,
                Points = 16
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 7,
                UserId = 1,
                SubjectId = 7,
                Points = 26
            });

            // User2

            model.Entity<Score>().HasData(new Score
            {
                Id = 8,
                UserId = 2,
                SubjectId = 1,
                Points = 6
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 9,
                UserId = 2,
                SubjectId = 2,
                Points = 15
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 10,
                UserId = 2,
                SubjectId = 3,
                Points = 0
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 11,
                UserId = 2,
                SubjectId = 4,
                Points = 7
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 12,
                UserId = 2,
                SubjectId = 5,
                Points = 12
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 13,
                UserId = 2,
                SubjectId = 6,
                Points = 33
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 14,
                UserId = 2,
                SubjectId = 7,
                Points = 8
            });

            // User 3

            model.Entity<Score>().HasData(new Score
            {
                Id = 15,
                UserId = 3,
                SubjectId = 1,
                Points = 4
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 16,
                UserId = 3,
                SubjectId = 2,
                Points = 11
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 17,
                UserId = 3,
                SubjectId = 3,
                Points = 7
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 18,
                UserId = 3,
                SubjectId = 4,
                Points = 27
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 19,
                UserId = 3,
                SubjectId = 5,
                Points = 14
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 20,
                UserId = 3,
                SubjectId = 6,
                Points = 36
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 21,
                UserId = 3,
                SubjectId = 7,
                Points = 1
            });

            // User 4

            model.Entity<Score>().HasData(new Score
            {
                Id = 22,
                UserId = 4,
                SubjectId = 1,
                Points = 2
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 23,
                UserId = 4,
                SubjectId = 2,
                Points = 0
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 24,
                UserId = 4,
                SubjectId = 3,
                Points = 14
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 25,
                UserId = 4,
                SubjectId = 4,
                Points = 10
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 26,
                UserId = 4,
                SubjectId = 5,
                Points = 14
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 27,
                UserId = 4,
                SubjectId = 6,
                Points = 5
            });
            model.Entity<Score>().HasData(new Score
            {
                Id = 28,
                UserId = 4,
                SubjectId = 7,
                Points = 33
            });

            //           //
            // Test data //
            //           //

            model.Entity<Test>().HasData(new Test
            {
                Id = 1,
                SubjectId = 1,
                NumberOfQuestions = 3,
                StartTime = new DateTime(2022, 4, 30, 12, 50, 00),
                TestTimeInMinutes = 60
            });
            model.Entity<Test>().HasData(new Test
            {
                Id = 2,
                SubjectId = 1,
                NumberOfQuestions = 4,
                StartTime = new DateTime(2022, 5, 10, 12, 50, 00),
                TestTimeInMinutes = 60
            });
            model.Entity<Test>().HasData(new Test
            {
                Id = 3,
                SubjectId = 2,
                NumberOfQuestions = 2,
                StartTime = new DateTime(2022, 5, 10, 12, 50, 00),
                TestTimeInMinutes = 60
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
