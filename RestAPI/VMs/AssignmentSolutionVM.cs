using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class AssignmentSolutionVM
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
        [Column(TypeName = "decimal(2, 2)")]
        public decimal? Grade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }
}
