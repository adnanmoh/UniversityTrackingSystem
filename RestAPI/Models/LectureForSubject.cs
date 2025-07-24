using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    public class LectureForSubject
    {
       

        [Key]
        [Column("LectureID")]
        public int LectureId { get; set; }
        [Key]
        [Column("SubjectID")]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(LectureId))]
        [InverseProperty(nameof(Lecture.LectureForSubjects))]
        public virtual Lecture Lecturee { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.LectureForSubjects))]
        public virtual Subject Subjectt { get; set; } = null!;


    }
}
