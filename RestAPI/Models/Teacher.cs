using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    [Index(nameof(IdNumber), Name = "UQ__Teachers__62DF8033E4024964", IsUnique = true)]
    [Index(nameof(Email), Name = "UQ__Teachers__A9D10534EF942E65", IsUnique = true)]
    public partial class Teacher
    {
        public Teacher()
        {
            Assignments = new HashSet<Assignment>();
            Grades = new HashSet<Grade>();
            TeacherSchedules = new HashSet<TeacherSchedule>();
            Teachings = new HashSet<Teaching>();
            Courses = new HashSet<Course>();
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        [Column("TeacherID")]
        public int TeacherId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string IdNumber { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Password { get; set; } = null!;

        [StringLength(255)]
        [Unicode(false)]
        public string PasswordHash { get; set; } = null!;

        [InverseProperty(nameof(Assignment.Teacher))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(Grade.Teacher))]
        public virtual ICollection<Grade> Grades { get; set; }
        [InverseProperty(nameof(TeacherSchedule.Teacher))]
        public virtual ICollection<TeacherSchedule> TeacherSchedules { get; set; }
        [InverseProperty(nameof(Teaching.Teacher))]
        public virtual ICollection<Teaching> Teachings { get; set; }
        [InverseProperty(nameof(Course.Teacher))]
        public virtual ICollection<Course> Courses { get; set; }

        [InverseProperty(nameof(Attachment.Teacher))]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
