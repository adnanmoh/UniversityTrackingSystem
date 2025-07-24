using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Attendances = new HashSet<Attendance>();
            Subjects = new HashSet<Subject>();
            LectureForSubjects = new HashSet<LectureForSubject>();
        }

        [Key]
        [Column("LectureID")]
        public int LectureId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Attendance.Lecture))]
        public virtual ICollection<Attendance> Attendances { get; set; }

        [ForeignKey("LectureId")]
        [InverseProperty(nameof(Subject.Lectures))]
        public virtual ICollection<Subject> Subjects { get; set; }
        [InverseProperty(nameof(LectureForSubject.Lecturee))]
        public virtual ICollection<LectureForSubject> LectureForSubjects { get; set; }

    }
}
