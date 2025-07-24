using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    public class Attachment
    {
        [Key]
        [Column("AttachmentID")]
        public int AttachmentId { get; set; }
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
        [InverseProperty("Attachments")]
        public virtual Year Year { get; set; } = null!;
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Attachments")]
        public virtual Group Group { get; set; } = null!;
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Attachments")]
        public virtual Teacher Teacher { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Attachments")]
        public virtual Subject Subject { get; set; } = null!;
    }
}
