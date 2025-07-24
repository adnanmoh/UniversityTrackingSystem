using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Year
    {
        public Year()
        {
            Assignments = new HashSet<Assignment>();
            Grades = new HashSet<Grade>();
            Groups = new HashSet<Group>();
            StudentSchedules = new HashSet<StudentSchedule>();
            TeacherSchedules = new HashSet<TeacherSchedule>();
            Teachings = new HashSet<Teaching>();
            Courses = new HashSet<Course>();
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        [Column("YearID")]
        public int YearId { get; set; }
        [Column("Year")]
        public int Year1 { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        [InverseProperty(nameof(Assignment.Year))]
        public virtual ICollection<Assignment> Assignments { get; set; }

        [InverseProperty(nameof(Grade.Year))]
        public virtual ICollection<Grade> Grades { get; set; }
        [InverseProperty(nameof(Group.Year))]
        public virtual ICollection<Group> Groups { get; set; }
        [InverseProperty(nameof(StudentSchedule.Year))]
        public virtual ICollection<StudentSchedule> StudentSchedules { get; set; }
        [InverseProperty(nameof(TeacherSchedule.Year))]
        public virtual ICollection<TeacherSchedule> TeacherSchedules { get; set; }
        [InverseProperty(nameof(Teaching.Year))]
        public virtual ICollection<Teaching> Teachings { get; set; }

        [InverseProperty(nameof(Course.Year))]
        public virtual ICollection<Course> Courses { get; set; }

        [InverseProperty(nameof(Attachment.Year))]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }

}