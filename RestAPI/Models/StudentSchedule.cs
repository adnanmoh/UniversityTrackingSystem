using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    [Table("StudentSchedule")]
    public partial class StudentSchedule
    {
        [Key]
        [Column("ScheduleID")]
        public int ScheduleId { get; set; }
        [Column("SFile")]
        public byte[]? Sfile { get; set; } 

        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; } = DateTime.Now;

        [Column("YearID")]
        public int YearId { get; set; }
        [Column("TermID")]
        public int TermId { get; set; }
        [Column("GroupID")]
        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("StudentSchedules")]
        public virtual Group Group { get; set; } = null!;
        [ForeignKey(nameof(TermId))]
        [InverseProperty("StudentSchedules")]
        public virtual Term Term { get; set; } = null!;
        [ForeignKey(nameof(YearId))]
        [InverseProperty("StudentSchedules")]
        public virtual Year Year { get; set; } = null!;
    }
}
