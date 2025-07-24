using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        [Column("AttendanceID")]
        public int AttendanceId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string State { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Reason { get; set; }
        [Column("RFile")]
        public byte[]? Rfile { get; set; }
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Column("SubjectID")]
        public int SubjectId { get; set; }
        [Column("LectureID")]
        public int LectureId { get; set; }
       
        [ForeignKey(nameof(LectureId))]
        [InverseProperty("Attendances")]
        public virtual Lecture Lecture { get; set; } = null!;
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Attendances")]
        public virtual Student Student { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Attendances")]
        public virtual Subject Subject { get; set; } = null!;
        
    }
}
