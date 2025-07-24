using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class AssignmentSolution
    {
        [Key]
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Key]
        [Column("AssignmentID")]
        public int AssignmentId { get; set; }
        [Column("ANote", TypeName = "text")]
        public string? Anote { get; set; }
        [Column("AFile")]
        public byte[]? Afile { get; set; }
        [Column(TypeName = "float")]
        public decimal? Grade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(AssignmentId))]
        [InverseProperty("AssignmentSolutions")]
        public virtual Assignment Assignment { get; set; } = null!;
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("AssignmentSolutions")]
        public virtual Student Student { get; set; } = null!;
    }
}
