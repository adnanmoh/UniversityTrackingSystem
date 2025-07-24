using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Assignments = new HashSet<Assignment>();
            Attendances = new HashSet<Attendance>();
            Grades = new HashSet<Grade>();
            Teachings = new HashSet<Teaching>();
            Lectures = new HashSet<Lecture>();
            LectureForSubjects = new HashSet<LectureForSubject>();
            SubjectsInMajorsLevels = new HashSet<SubjectsInMajorsLevel>();
            Courses = new HashSet<Course>();
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        [Column("SubjectID")]
        public int SubjectId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Type { get; set; } = null!;
        public bool Status { get; set; }

        [InverseProperty(nameof(Assignment.Subject))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(Attendance.Subject))]
        public virtual ICollection<Attendance> Attendances { get; set; }

        [InverseProperty(nameof(Grade.Subject))]
        public virtual ICollection<Grade> Grades { get; set; }

        [InverseProperty(nameof(Teaching.Subject))]
        public virtual ICollection<Teaching> Teachings { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty(nameof(Lecture.Subjects))]
        public virtual ICollection<Lecture> Lectures { get; set; }
        [InverseProperty(nameof(LectureForSubject.Subjectt))]
        public virtual ICollection<LectureForSubject> LectureForSubjects { get; set; }
        [InverseProperty(nameof(SubjectsInMajorsLevel.Subjectt))]
        public virtual ICollection<SubjectsInMajorsLevel> SubjectsInMajorsLevels { get; set; }

        [InverseProperty(nameof(Course.Subject))]
        public virtual ICollection<Course> Courses { get; set; }

        [InverseProperty(nameof(Attachment.Subject))]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
