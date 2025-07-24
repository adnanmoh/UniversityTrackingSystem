using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Grade
    {
       

        [Key]
        [Column("GradeID")]
        public int GradeId { get; set; }
        [Column("SubjectID")]
        public int SubjectId { get; set; }
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Column("TeacherID")]
        public int TeacherId { get; set; }
        [Column("YearID")]
        public int YearId { get; set; }

        [Column(TypeName = "float")]
        public decimal? Attendance { get; set; }

        [Column(TypeName = "float")]
        public decimal? Exam { get; set; }

        [Column(TypeName = "float")]
        public decimal? participation { get; set; }

        public bool IsPosted { get; set; } = false;

        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Grades")]
        public virtual Student Student { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Grades")]
        public virtual Subject Subject { get; set; } = null!;
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Grades")]
        public virtual Teacher Teacher { get; set; } = null!;
       
        [ForeignKey(nameof(YearId))]
        [InverseProperty("Grades")]
        public virtual Year Year { get; set; } = null!;

    }
}
