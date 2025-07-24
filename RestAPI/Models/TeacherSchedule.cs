using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    [Table("TeacherSchedule")]
    public partial class TeacherSchedule
    {
        [Key]
        [Column("ScheduleID")]
        public int ScheduleId { get; set; }
        [Column("SFile")]
        public byte[]? Sfile { get; set; } 

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; } = DateTime.Now;

        [Column("TeacherID")]
        public int TeacherId { get; set; }
        [Column("TermID")]
        public int TermId { get; set; }
        [Column("YearID")]
        public int YearId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("TeacherSchedules")]
        public virtual Teacher Teacher { get; set; } = null!;
        [ForeignKey(nameof(TermId))]
        [InverseProperty("TeacherSchedules")]
        public virtual Term Term { get; set; } = null!;
        [ForeignKey(nameof(YearId))]
        [InverseProperty("TeacherSchedules")]
        public virtual Year Year { get; set; } = null!;
    }
}
