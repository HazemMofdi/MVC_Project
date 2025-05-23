using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{

    public class AppDbContext : DbContext
    {
       

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ProgressTracking> ProgressTrackings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Therapist>().HasData
                (
                    new Therapist
                    {
                        Id = 1,
                        FullName = "Hazem Mofdi",
                        Password = "12345678",
                        ImagePath = "doctors-1.jpg",
                        Email = "HazemMofdi11@gmail.com",
                        Bio = "Experienced therapist with 10+ years of practice. Specializes in anxiety and depression.",
                        Rating = 5,
                        Availability = "Mon-Fri, 9 AM - 5 PM"
                    },

                    new Therapist
                    {
                        Id = 2,
                        FullName = "Hassan Atef",
                        Password = "12345678",
                        ImagePath = "doctors-1.jpg",
                        Email = "HassanAtef10@gmail.com",
                        Bio = "Specializes in stress management and burnout. Helps clients develop coping strategies.",
                        Rating = 5,
                        Availability = "Tue-Thu, 10 AM - 6 PM"
                    },

                    new Therapist
                    {

                        Id = 3,
                        FullName = "Rahma Tarek",
                        Password = "12345678",
                        ImagePath = "doctors-2.jpg",
                        Email = "RahmaTarek111@gmail.com",
                        Bio = "Specializes in trauma-informed therapist who specializes in helping clients heal from PTSD and complex trauma",
                        Rating = 5,
                        Availability = "Mon-Wed, 11 AM - 7 PM"
                    },

                    new Therapist
                    {
                        Id = 4,
                        FullName = "Nancy Saad",
                        Password = "12345678",
                        ImagePath = "doctors-2.jpg",
                        Email = "NancySaad111@gmail.com",
                        Bio = "Specializes in workplace stress and burnout. She helps clients manage stress, improve work-life balance, and develop resilience through mindfulness and stress-reduction techniques.",
                        Rating = 5,
                        Availability = "Wed-Fri, 12 PM - 8 PM"
                    },

                    new Therapist
                    {
                        Id = 5,
                        FullName = "Hamss Mohammed",
                        Password = "12345678",
                        ImagePath = "doctors-2.jpg",
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
                        FullName = "Sarah Ahmed",
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
                        FullName = "Mohammed Mahmoud",
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
                        FullName = "Toqa Ali",
                        Email = "ToqaAli25@gmail.com",
                        Password = "12345678",
                        PhoneNumber = "01044445678",
                        DateOfBirth = new DateTime(2000, 3, 15),
                        Gender = GenderEnum.Male.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.MildDepression.ToString(),
                        Preferences = "Prefers Chat"
                    },
                    new User
                    {
                        Id = 4,
                        FullName = "Yara Hassan",
                        Email = "Yara.Hassan@example.com",
                        Password = "SecurePass123",
                        PhoneNumber = "01055556789",
                        DateOfBirth = new DateTime(1995, 8, 22),
                        Gender = GenderEnum.Female.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.Anxiety.ToString(),
                        Preferences = "Prefers video calls"
                    },
                    new User
                    {
                        Id = 5,
                        FullName = "Omar Ibrahim",
                        Email = "Omar.Ibrahim@example.com",
                        Password = "OmarPass2023",
                        PhoneNumber = "01066667890",
                        DateOfBirth = new DateTime(1998, 11, 5),
                        Gender = GenderEnum.Male.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.PanicDisorder.ToString(),
                        Preferences = "Prefers text therapy"
                    },
                    new User
                    {
                        Id = 6,
                        FullName = "Lina Mahmoud",
                        Email = "Lina.Mahmoud@example.com",
                        Password = "Lina123!",
                        PhoneNumber = "01077778901",
                        DateOfBirth = new DateTime(1992, 4, 30),
                        Gender = GenderEnum.Female.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.PTSD.ToString(),
                        Preferences = "Prefers evening sessions"
                    },
                    new User
                    {
                        Id = 7,
                        FullName = "Karim Adel",
                        Email = "Karim.Adel@example.com",
                        Password = "Karim@789",
                        PhoneNumber = "01088889012",
                        DateOfBirth = new DateTime(1997, 7, 14),
                        Gender = GenderEnum.Male.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.OCD.ToString(),
                        Preferences = "Prefers weekly sessions"
                    },
                    new User
                    {
                        Id = 8,
                        FullName = "Nour Samir",
                        Email = "Nour.Samir@example.com",
                        Password = "NourPass!",
                        PhoneNumber = "01099990123",
                        DateOfBirth = new DateTime(2001, 1, 18),
                        Gender = GenderEnum.Female.ToString(),
                        HealthAssessmentResults = HealthAssessmentResultEnum.MildDepression.ToString(),
                        Preferences = "Prefers female therapists"
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
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Session on workplace stress and burnout."
                    },

                    new Session
                    {
                        Id = 5,
                        UserID = 2, // (Mohamed)
                        TherapistID = 5, //(Hamss)
                        SessionDate = new DateTime(2025, 4, 30),
                        SessionType = SessionTypeEnum.Chat.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Session on OCD management."
                    },
                    new Session
                    {
                        Id = 6,
                        UserID = 4, // Yara
                        TherapistID = 1, // Hazem
                        SessionDate = new DateTime(2025, 4, 28),
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Initial consultation for anxiety."
                    },
                    new Session
                    {
                        Id = 7,
                        UserID = 5, // Omar
                        TherapistID = 1, // Hazem
                        SessionDate = new DateTime(2025, 7, 4),
                        SessionType = SessionTypeEnum.Chat.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Session for panic disorder support."
                    },
                    new Session
                    {
                        Id = 8,
                        UserID = 6, // Lina
                        TherapistID = 2, // Hassan
                        SessionDate = new DateTime(2025, 5, 2),
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Evening-preference client, PTSD therapy."
                    },
                    new Session
                    {
                        Id = 9,
                        UserID = 7, // Karim
                        TherapistID = 4, // Nancy
                        SessionDate = new DateTime(2025, 5, 4),
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "OCD-focused discussion and planning."
                    },
                    new Session
                    {
                        Id = 10,
                        UserID = 8, // Nour
                        TherapistID = 5, // Hamss
                        SessionDate = new DateTime(2025, 5, 3),
                        SessionType = SessionTypeEnum.VideoCall.ToString(),
                        SessionStatus = SessionStatusEnum.Booked.ToString(),
                        SessionNotes = "Session for mild depression, female therapist requested."
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
                    },
                    new ProgressTracking
                    {
                        Id = 6,
                        UserID = 4, // Yara
                        Date = new DateTime(2025, 4, 30),
                        MoodRating = MoodRatingEnum.AboveAverage.ToString(),
                        Goals = "Develop coping strategies for anxiety",
                        ProgressNotes = "Reported reduced anxiety in social situations."
                    },
                    new ProgressTracking
                    {
                        Id = 7,
                        UserID = 5, // Omar
                        Date = new DateTime(2025, 7, 6),
                        MoodRating = MoodRatingEnum.Good.ToString(),
                        Goals = "Handle panic triggers more calmly",
                        ProgressNotes = "Felt more in control during anxious moments."
                    },
                    new ProgressTracking
                    {
                        Id = 8,
                        UserID = 6, // Lina
                        Date = new DateTime(2025, 5, 4), 
                        MoodRating = MoodRatingEnum.Average.ToString(),
                        Goals = "Build resilience to trauma-related stress",
                        ProgressNotes = "Struggled slightly but remains optimistic."
                    },
                    new ProgressTracking
                    {
                        Id = 9,
                        UserID = 7, // Karim
                        Date = new DateTime(2025, 5, 6),
                        MoodRating = MoodRatingEnum.VeryGood.ToString(),
                        Goals = "Reduce compulsive behavior",
                        ProgressNotes = "Reported fewer OCD episodes this week."
                    },
                    new ProgressTracking
                    {
                        Id = 10,
                        UserID = 8, // Nour
                        Date = new DateTime(2025, 5, 5),
                        MoodRating = MoodRatingEnum.Good.ToString(),
                        Goals = "Enhance self-esteem and positivity",
                        ProgressNotes = "Feeling more emotionally balanced."
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
                    },
                    new Review
                    {
                        Id = 6,
                        UserID = 4,
                        TherapistID = 1,
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Mr. Hazem really helped me understand and manage my anxiety better. He’s a great listener!",
                        ReviewDate = new DateTime(2025, 5, 1)
                    },
                    new Review
                    {
                        Id = 7,
                        UserID = 5, 
                        TherapistID = 1, 
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Very supportive and calm atmosphere. Hazem provided solid strategies for panic disorder.",
                        ReviewDate = new DateTime(2025, 7, 6)
                    },

                    new Review
                    {
                        Id = 8,
                        UserID = 6, 
                        TherapistID = 2, 
                        Rating = ReviewRatingEnum.Good.ToString(),
                        ReviewText = "Hassan was empathetic and offered helpful evening sessions. Could improve in follow-up.",
                        ReviewDate = new DateTime(2025, 5, 4)
                    },

                    new Review
                    {
                        Id = 9,
                        UserID = 7, 
                        TherapistID = 4, 
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Nancy made me feel heard. Great experience with OCD management strategies!",
                        ReviewDate = new DateTime(2025, 5, 6)
                    },

                    new Review
                    {
                        Id = 10,
                        UserID = 8, 
                        TherapistID = 5,
                        Rating = ReviewRatingEnum.Excellent.ToString(),
                        ReviewText = "Felt very comfortable talking to Hamss. Appreciated her compassionate approach.",
                        ReviewDate = new DateTime(2025, 5, 6)
                    }
                );
        }
    }
}
