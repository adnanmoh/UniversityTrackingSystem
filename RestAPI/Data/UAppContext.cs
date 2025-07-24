using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestAPI.Models;

namespace RestAPI.Data
{
    public partial class UAppContext : IdentityDbContext<SysUser>
    {
        public UAppContext()
        {
        }

        public UAppContext(DbContextOptions<UAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentSolution> AssignmentSolutions { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<College> Colleges { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<LectureForSubject> LecturesForSubjects { get; set; } = null!;
        public virtual DbSet<Level> Levels { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<NotificationType> NotificationTypes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentSchedule> StudentSchedules { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeacherSchedule> TeacherSchedules { get; set; } = null!;
        public virtual DbSet<Teaching> Teachings { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;
        public virtual DbSet<Year> Years { get; set; } = null!;
        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<SubjectsInMajorsLevel> SubjectsInMajorsLevel { get; set; } = null!;


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-8742SGS\\ADNAN;Database=UApp;Trusted_Connection = yes;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Subje__3B75D760");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Teach__398D8EEE");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__YearI__3A81B327");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__Subje__3B75D760");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__Teach__398D8EEE");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__YearI__3A81B327");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__Group__3A81B327");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attachment__Subje__3B75D760");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attachment__Teach__398D8EEE");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attachment__YearI__3A81B327");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attachment__Group__3A81B327");
            });

            modelBuilder.Entity<AssignmentSolution>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.AssignmentId })
                    .HasName("PK__Assignme__51E1B39C8E0034DB");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.AssignmentSolutions)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Assig__7A672E12");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AssignmentSolutions)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Stude__797309D9");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendanc__Lectu__693CA210");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendanc__Stude__6754599E");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendanc__Subje__68487DD7");

              
            });

            modelBuilder.Entity<LectureForSubject>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.LectureId })
                    .HasName("PK__Lect__CF3E342244FF46B1");

                entity.HasOne(d => d.Lecturee)
                    .WithMany(p => p.LectureForSubjects)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lect__subj__5535A963");

                entity.HasOne(d => d.Subjectt)
                    .WithMany(p => p.LectureForSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lect__Subje__5441852A");
            });

            modelBuilder.Entity<SubjectsInMajorsLevel>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.MajorId })
                    .HasName("PK__SubjectsInMajorsLevel__CF3E342244FF46B1");

                entity.HasOne(d => d.Majorr)
                    .WithMany(p => p.SubjectsInMajorsLevels)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectsInMajorsLevel__5535A963");

                entity.HasOne(d => d.Subjectt)
                    .WithMany(p => p.SubjectsInMajorsLevels)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectsInMajorsLevel__5441852A");

                entity.HasOne(d => d.Levell)
                    .WithMany(p => p.SubjectsInMajorsLevels)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectsInMajorsLevel__5333352A");

                
            });



            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grades__StudentI__7E37BEF6");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grades__SubjectI__7D439ABD");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grades__TeacherI__7F2BE32F");

               

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grades__YearID__00200768");
            });

            

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Groups__LevelID__5DCAEF64");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Groups__MajorID__5EBF139D");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Groups__YearID__5CD6CB2B");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasMany(d => d.Subjects)
                    .WithMany(p => p.Lectures)
                    .UsingEntity<Dictionary<string, object>>(
                        "LecturesForSubject",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("SubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LecturesF__Subje__46E78A0C"),
                        r => r.HasOne<Lecture>().WithMany().HasForeignKey("LectureId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LecturesF__Lectu__45F365D3"),
                        j =>
                        {
                            j.HasKey("LectureId", "SubjectId").HasName("PK__Lectures__2DF84CA73B42459B");

                            j.ToTable("LecturesForSubject");

                            j.IndexerProperty<int>("LectureId").HasColumnName("LectureID");

                            j.IndexerProperty<int>("SubjectId").HasColumnName("SubjectID");
                        });
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.HasOne(d => d.College)
                    .WithMany(p => p.Majors)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Majors__CollegeI__2F10007B");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.NotificationType)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NotificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Notif__0B91BA14");
            });

           
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__GroupI__6383C8BA");
            });

            modelBuilder.Entity<StudentSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__StudentS__9C8A5B69A311BE0E");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentSchedules)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentSc__Group__6EF57B66");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.StudentSchedules)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentSc__TermI__6E01572D");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.StudentSchedules)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentSc__YearI__6D0D32F4");
            });

           
            modelBuilder.Entity<TeacherSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__TeacherS__9C8A5B695414ABED");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSchedules)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeacherSc__Teach__412EB0B6");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.TeacherSchedules)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeacherSc__TermI__4222D4EF");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.TeacherSchedules)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeacherSc__YearI__4316F928");
            });

            modelBuilder.Entity<Teaching>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.GroupId, e.SubjectId, e.MajorId, e.YearId, e.TermId })
                    .HasName("PK__Teaching__945231760E2B4305");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Teachings)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaching__GroupI__72C60C4A");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Teachings)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaching__MajorI__74AE54BC");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teachings)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaching__Subjec__73BA3083");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Teachings)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaching__Teache__71D1E811");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Teachings)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaching__TermID__76969D2E");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Teachings)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teaching__YearID__75A278F5");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
