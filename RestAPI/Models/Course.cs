using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    public class Course
    {
        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [Column("File")]
        public byte[] File { get; set; } = null!;
        [Column("Note", TypeName = "text")]
        public string Note { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; } = DateTime.Now;
        [Column("YearID")]
        public int YearId { get; set; }
        [Column("GroupID")]
        public int GroupId { get; set; }
        [Column("TeacherID")]
        public int TeacherId { get; set; }
        [Column("SubjectID")]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(YearId))]
        [InverseProperty("Courses")]
        public virtual Year Year { get; set; } = null!;
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Courses")]
        public virtual Group Group { get; set; } = null!;
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Courses")]
        public virtual Teacher Teacher { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Courses")]
        public virtual Subject Subject { get; set; } = null!;
    }
}
