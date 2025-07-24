using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    [Table("Teaching")]
    public partial class Teaching
    {
        [Key]
        [Column("TeacherID")]
        public int TeacherId { get; set; }
        [Key]
        [Column("GroupID")]
        public int GroupId { get; set; }
        [Key]
        [Column("SubjectID")]
        public int SubjectId { get; set; }
        [Key]
        [Column("MajorID")]
        public int MajorId { get; set; }
        [Key]
        [Column("YearID")]
        public int YearId { get; set; }
        [Key]
        [Column("TermID")]
        public int TermId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Teachings")]
        public virtual Group Group { get; set; } = null!;
        [ForeignKey(nameof(MajorId))]
        [InverseProperty("Teachings")]
        public virtual Major Major { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Teachings")]
        public virtual Subject Subject { get; set; } = null!;
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Teachings")]
        public virtual Teacher Teacher { get; set; } = null!;
        [ForeignKey(nameof(TermId))]
        [InverseProperty("Teachings")]
        public virtual Term Term { get; set; } = null!;
        [ForeignKey(nameof(YearId))]
        [InverseProperty("Teachings")]
        public virtual Year Year { get; set; } = null!;
    }
}
