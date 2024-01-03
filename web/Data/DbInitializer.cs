using web.Models;
using System;
using System.Linq;
using web.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EMIContext context)
        {
            context.Database.EnsureCreated();
            
            // Look for any students.
            if (context.Dormitories.Any())
            {
                return;   // DB has been seeded
            }

            var dormitories = new Dormitory[]
            {
            new Dormitory{DormitoryTitle="Dom 1", JanitorPhoneNumber="041123123"},
            new Dormitory{DormitoryTitle="Dom 12", JanitorPhoneNumber="051234876"},
            new Dormitory{DormitoryTitle="Dom ŠD3", JanitorPhoneNumber="031874562"}
            };

            foreach (Dormitory d in dormitories)
            {
                context.Dormitories.Add(d);
            }
            context.SaveChanges();
            
            var students = new Student[]
            {
            new Student{FirstName="Miha",LastName="Bajt",BirthDate=DateTime.Parse("2000-04-05").Date, Points=0, DormitoryID=1},
            new Student{FirstName="Matija",LastName="Slejko",BirthDate=DateTime.Parse("2002-09-01").Date, Points=0, DormitoryID=2},
            new Student{FirstName="Žiga",LastName="Koritnik",BirthDate=DateTime.Parse("2003-03-23").Date, Points=0, DormitoryID=3},
            new Student{FirstName="Jani",LastName="Rovtar",BirthDate=DateTime.Parse("2002-06-14").Date, Points=0, DormitoryID=3},
            new Student{FirstName="Leon",LastName="Tratnik",BirthDate=DateTime.Parse("2002-07-12").Date, Points=0, DormitoryID=2},
            new Student{FirstName="Sašo",LastName="Vončina",BirthDate=DateTime.Parse("2001-01-11").Date, Points=0, DormitoryID=1},
            new Student{FirstName="Nejc",LastName="Lazić",BirthDate=DateTime.Parse("2003-02-12").Date, Points=0, DormitoryID=1},
            new Student{FirstName="Urban",LastName="Melink",BirthDate=DateTime.Parse("2000-04-22").Date, Points=0, DormitoryID=3}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            
            var events = new Event[]
            {
            new Event{EventID=1, EventTitle="Tek na vrh Doma 14",EventDescription="Tekmovalec mora v čim krajšem času preteči na vrh Doma 14 in med tekom popiti cel 6 pack. Nagrada: 10 točk.", EventDate=DateTime.Parse("2024-05-01 14:30:00"), PrizeFund=10, FirstPlace=0, SecondPlace=0, ThirdPlace=0},
            new Event{EventID=2, EventTitle="Briškula",EventDescription="Tekmovalec igra v ekipi dveh članov turnir v briškuli. Nagrada: 2 točki.", EventDate=DateTime.Parse("2024-05-06 15:00:00"), PrizeFund=12, FirstPlace=0, SecondPlace=0, ThirdPlace=0},
            new Event{EventID=3, EventTitle="Eksanje šnopca",EventDescription="Tekmovalec mora v čim krajšem času preteči spiti pol litra šnopca. Nagrada: 8 točk.", EventDate=DateTime.Parse("2024-05-11 18:30:00"),  PrizeFund=8, FirstPlace=0, SecondPlace=0, ThirdPlace=0}
            };
            foreach (Event e in events)
            {
                context.Events.Add(e);
            }
            context.SaveChanges();
            
            var enrollments = new Enrollment[]
            {
            new Enrollment{EnrollmentDate=DateTime.Parse("2024-04-06 15:22:11"), StudentID=1,EventID=1},
            new Enrollment{EnrollmentDate=DateTime.Parse("2024-04-22 11:11:22"), StudentID=1,EventID=1},
            new Enrollment{EnrollmentDate=DateTime.Parse("2024-04-11 12:05:11"), StudentID=2,EventID=2},
            new Enrollment{EnrollmentDate=DateTime.Parse("2024-04-04 15:15:11"), StudentID=3,EventID=2},
            new Enrollment{EnrollmentDate=DateTime.Parse("2024-04-01 18:22:11"), StudentID=1,EventID=3}
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();

            var roles = new IdentityRole[] 
            {
                new IdentityRole{Id="1", Name="Administrator"},
                new IdentityRole{Id="2", Name="Student",NormalizedName="STUDENT"},
                new IdentityRole{Id="3", Name="Manager"}
            };
            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            context.SaveChanges();

            var user = new ApplicationUser
            {
                FirstName ="Bob",
                LastName = "Lazic",
                City = "Ljubljana",
                Email = "bob@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "bob@example.com",
                NormalizedUserName = "bob@example.com",
                PhoneNumber = "+36841576123",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if(!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Testni123!");
                user.PasswordHash = hashed;
                context.Users.Add(user);
            }

            context.SaveChanges();


            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId = user.Id}
            };

            foreach(IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }

            context.SaveChanges();

            
        }
    }
}