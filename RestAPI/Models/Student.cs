using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    [Index(nameof(IdNumber), Name = "UQ__Students__62DF8033EB9C3711", IsUnique = true)]
    public partial class Student
    {
        public Student()
        {
            AssignmentSolutions = new HashSet<AssignmentSolution>();
            Attendances = new HashSet<Attendance>();
            Grades = new HashSet<Grade>();
        }

        [Key]
        [Column("StudentID")]
        public int StudentId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string IdNumber { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Password { get; set; } = null!;

        [StringLength(255)]
        [Unicode(false)]
        public string PasswordHash { get; set; } = null!;

        [Column("GroupID")]
        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Students")]
        public virtual Group Group { get; set; } = null!;
        [InverseProperty(nameof(AssignmentSolution.Student))]
        public virtual ICollection<AssignmentSolution> AssignmentSolutions { get; set; }
        [InverseProperty(nameof(Attendance.Student))]
        public virtual ICollection<Attendance> Attendances { get; set; }
        [InverseProperty(nameof(Grade.Student))]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
