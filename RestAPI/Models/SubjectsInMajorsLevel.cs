using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    public class SubjectsInMajorsLevel
    {
        [Key]
        [Column("MajorID")]
        public int MajorId { get; set; }
        [Key]
        [Column("SubjectID")]
        public int SubjectId { get; set; }
        [Column("LevelID")]
        public int LevelId { get; set; }
        [Column("TermID")]
        public int TermId { get; set; }

        [ForeignKey(nameof(MajorId))]
        [InverseProperty(nameof(Major.SubjectsInMajorsLevels))]
        public virtual Major Majorr { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.SubjectsInMajorsLevels))]
        public virtual Subject Subjectt { get; set; } = null!;
        [ForeignKey(nameof(LevelId))]
        [InverseProperty(nameof(Level.SubjectsInMajorsLevels))]
        public virtual Level Levell { get; set; } = null!;

        [ForeignKey(nameof(TermId))]
        [InverseProperty(nameof(Term.SubjectsInMajorsLevels))]
        public virtual Term Termm { get; set; } = null!;
    }
}
