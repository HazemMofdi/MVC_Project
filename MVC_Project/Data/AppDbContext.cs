using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ProgressTracking> ProgressTrackings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Therapist>().HasData
                (
                    new Therapist
                    {
                        Id = 1,
                        FName = "Hazem",
                        LName = "Mofdi",
                        Email = "HazemMofdi11@gmail.com",
                        Bio = "Experienced therapist with 10+ years of practice. Specializes in anxiety and depression.",
                        Rating = 5,
                        Availability = "Mon-Fri, 9 AM - 5 PM"
                    },

                    new Therapist
                    {
                        Id = 2,
                        FName = "Hassan",
                        LName = "Atef",
                        Email = "HassanAtef10@gmail.com",
                        Bio = "Specializes in stress management and burnout. Helps clients develop coping strategies.",
                        Rating = 5,
                        Availability = "Tue-Thu, 10 AM - 6 PM"
                    },

                    new Therapist
                    {

                        Id = 3,
                        FName = "Rahma",
                        LName = "Tarek",
                        Email = "RahmaTarek111@gmail.com",
                        Bio = "Specializes in trauma-informed therapist who specializes in helping clients heal from PTSD and complex trauma",
                        Rating = 5,
                        Availability = "Mon-Wed, 11 AM - 7 PM"
                    },

                    new Therapist
                    {
                        Id = 4,
                        FName = "Nancy",
                        LName = "Saad",
                        Email = "NancySaad111@gmail.com",
                        Bio = "Specializes in workplace stress and burnout. She helps clients manage stress, improve work-life balance, and develop resilience through mindfulness and stress-reduction techniques.",
                        Rating = 5,
                        Availability = "Wed-Fri, 12 PM - 8 PM"
                    },

                    new Therapist
                    {
                        Id = 5,
                        FName = "Hamss",
                        LName = "Mohammed",
                        Email = "HamssMohamed111@gmail.com",
                        Bio = "licensed psychologist specializing in the treatment of Obsessive-Compulsive Disorder (OCD), She helps clients reduce compulsions and manage intrusive thoughts. With over 10 years of experience",
                        Rating = 5,
                        Availability = "Mon-Thu, 9 AM - 4 PM"
                    }
                );
            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------

            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = 1,
                        FName = "Sarah",
                        LName = "Ahmed",
                        Email = "SarahAhmed12@gmail.com",
                        Password = "123456",
                        PhoneNumber = "01012345678",
                        DateOfBirth = new DateTime(1999, 5, 15),
                        Gender = GenderEnum.Female.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.Anxiety.ToString(),
                        Preferences = "Prefers video calls"
                    },

                    new User
                    {
                        Id = 2,
                        FName = "Mohammed",
                        LName = "Mahmoud",
                        Email = "MohammedMahmoud33@gmail.com",
                        Password = "1234567",
                        PhoneNumber = "01033345678",
                        DateOfBirth = new DateTime(2003, 7, 15),
                        Gender = GenderEnum.Male.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.OCD.ToString(),
                        Preferences = "Prefers video calls"
                    },
                    new User
                    {
                        Id = 3,
                        FName = "Toqa",
                        LName = "Ali",
                        Email = "ToqaAli25@gmail.com",
                        Password = "12345678",
                        PhoneNumber = "01044445678",
                        DateOfBirth = new DateTime(2000, 3, 15),
                        Gender = GenderEnum.Male.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.MildDepression.ToString(),
                        Preferences = "Prefers Chat"
                    }
                );

            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Session>().HasData
                (
                    new Session
                    {
                        // UserID and TherapistID are Foreign Keys
                        Id = 1,
                        UserID = 1, // (Sarah)
                        TherapistID = 1, // (Hazem)
                        SessionDate = new DateTime(2025, 4, 4),
                        SessionTime = new TimeSpan(10, 0, 0), // 10:00 AM
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Initial consultation for anxiety management."
                    },

                    new Session
                    {
                        Id = 2,
                        UserID = 2, // (Mohamed)
                        TherapistID = 2, //(Hassan)
                        SessionDate = new DateTime(2025, 3, 3),
                        SessionTime = new TimeSpan(14, 0, 0), // 2:00 PM
                        SessionType = SessionTypeEnum.Chat.ToString(),
                        SessionStatus = SessionStatusEnum.Completed.ToString(),//COMPLETED
                        SessionNotes = "Follow-up session for stress management."
                    },

                    new Session
                    {
                        Id = 3,
                        UserID = 3, // (Ahmed)
                        TherapistID = 3, // (Rahma)
                        SessionDate = new DateTime(2025, 6, 6),
                        SessionTime = new TimeSpan(16, 0, 0), // 4:00 PM
                        SessionType = SessionTypeEnum.Chat.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Discussion on trauma recovery."
                    },

                    new Session
                    {
                        Id = 4,
                        UserID = 1, // (Sarah)
                        TherapistID = 4, // (Nancy)
                        SessionDate = new DateTime(2025, 5, 5),
                        SessionTime = new TimeSpan(11, 0, 0), // 11:00 AM
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Session on workplace stress and burnout."
                    },

                    new Session
                    {
                        Id = 5,
                        UserID = 2, // (Mohamed)
                        TherapistID = 5, //(Hamss)
                        SessionDate = new DateTime(2025, 4, 4),
                        SessionTime = new TimeSpan(13, 0, 0), // 1:00 PM
                        SessionType = SessionTypeEnum.Chat.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Session on OCD management."
                    }
                );

            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------

            modelBuilder.Entity<ProgressTracking>().HasData
                (
                    new ProgressTracking
                    {
                        // UserID is a Foreign Key
                        Id = 1,
                        UserID = 1, //(Sarah) 
                        Date = new DateTime(2025, 5, 5),
                        MoodRating = MoodRatingEnum.Good.ToString(),
                        Goals = "Reduce anxiety by 20%",
                        ProgressNotes = "Feeling better after the session."
                    },

                    new ProgressTracking
                    {
                        Id = 2,
                        UserID = 2, //(Mohamed)
                        Date = new DateTime(2025, 4, 3),//////////////
                        MoodRating = MoodRatingEnum.AboveAverage.ToString(),
                        Goals = "Manage stress levels",
                        ProgressNotes = "Noted improvement in mood."
                    },

                    new ProgressTracking
                    {
                        Id = 3,
                        UserID = 3, //(Ahmed)
                        Date = new DateTime(2025, 7, 6),
                        MoodRating = MoodRatingEnum.VeryGood.ToString(),
                        Goals = "Improve communication skills",
                        ProgressNotes = "Made progress in expressing feelings."
                    },

                    new ProgressTracking
                    {
                        Id = 4,
                        UserID = 1, //(Sarah)
                        Date = new DateTime(2025, 6, 5),
                        MoodRating = MoodRatingEnum.Excellent.ToString(),
                        Goals = "Continue anxiety management",
                        ProgressNotes = "Feeling more confident."
                    },

                    new ProgressTracking
                    {
                        Id = 5,
                        UserID = 2, //(Mohamed)
                        Date = new DateTime(2025, 4, 3),
                        MoodRating = MoodRatingEnum.Good.ToString(),
                        Goals = "Work on OCD management",
                        ProgressNotes = "Making steady progress."
                    }
                );

            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Review>().HasData
                (
                    //UserID and TherapistID are Foreing Keys
                    new Review
                    {
                        Id = 1,
                        UserID = 1, 
                        TherapistID = 1, 
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Dr. Hazem Mofdi was very understanding and helpful. Highly recommend!",
                        ReviewDate = new DateTime(2025, 8, 15)
                    },

                    new Review
                    {
                        Id = 2,
                        UserID = 2, 
                        TherapistID = 2,
                        Rating = ReviewRatingEnum.Good.ToString(),
                        ReviewText = "Dr. Hassan Atef provided useful stress management tips. Very professional.",
                        ReviewDate = new DateTime(2025, 9, 15)
                    },

                    new Review
                    {
                        Id = 3,
                        UserID = 3, 
                        TherapistID = 3,
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Dr. Rahma Tarek helped me a lot with my trauma recovery. Thank you!",
                        ReviewDate = new DateTime(2025, 10, 15)
                    },

                    new Review
                    {
                        Id = 4,
                        UserID = 1,
                        TherapistID = 4,
                        Rating = ReviewRatingEnum.Good.ToString(),
                        ReviewText = "Dr. Nancy Saad is very knowledgeable about workplace stress. Great session!",
                        ReviewDate = new DateTime(2025, 10, 16)
                    },

                    new Review
                    {
                        Id = 5,
                        UserID = 2,
                        TherapistID = 5,
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Dr. Hamss Mohammed is amazing at OCD management. Highly recommend!",
                        ReviewDate = new DateTime(2025, 7, 7)
                    }
                );
        }
    }
}
