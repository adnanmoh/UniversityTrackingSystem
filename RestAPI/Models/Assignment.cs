using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentSolutions = new HashSet<AssignmentSolution>();
        }

        [Key]
        [Column("AssignmentID")]
        public int AssignmentId { get; set; }
        public int Number { get; set; }
        [Column("QTitle", TypeName = "text")]
        public string? Qtitle { get; set; }
        [Column("QText", TypeName = "text")]
        public string? Qtext { get; set; }
        [Column("QFile")]
        public byte[]? Qfile { get; set; }
        [Column(TypeName = "float")]
        public decimal MaxGrade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        [Column("TeacherID")]
        public int TeacherId { get; set; }
        [Column("YearID")]
        public int YearId { get; set; }
        [Column("SubjectID")]
        public int SubjectId { get; set; }
        [Column("GroupID")]
        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Assignments")]
        public virtual Group Group { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Assignments")]
        public virtual Subject Subject { get; set; } = null!;
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Assignments")]
        public virtual Teacher Teacher { get; set; } = null!;
        [ForeignKey(nameof(YearId))]
        [InverseProperty("Assignments")]
        public virtual Year Year { get; set; } = null!;
        [InverseProperty(nameof(AssignmentSolution.Assignment))]
        public virtual ICollection<AssignmentSolution> AssignmentSolutions { get; set; }
    }
}
