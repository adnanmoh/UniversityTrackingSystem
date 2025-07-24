using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Term
    {
        public Term()
        {
           
            StudentSchedules = new HashSet<StudentSchedule>();
            SubjectsInMajorsLevels = new HashSet<SubjectsInMajorsLevel>();
            TeacherSchedules = new HashSet<TeacherSchedule>();
            Teachings = new HashSet<Teaching>();
        }

        [Key]
        [Column("TermID")]
        public int TermId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        
        [InverseProperty(nameof(StudentSchedule.Term))]
        public virtual ICollection<StudentSchedule> StudentSchedules { get; set; }
        [InverseProperty(nameof(SubjectsInMajorsLevel.Termm))]
        public virtual ICollection<SubjectsInMajorsLevel> SubjectsInMajorsLevels { get; set; }
        [InverseProperty(nameof(TeacherSchedule.Term))]
        public virtual ICollection<TeacherSchedule> TeacherSchedules { get; set; }
        [InverseProperty(nameof(Teaching.Term))]
        public virtual ICollection<Teaching> Teachings { get; set; }
    }
}
