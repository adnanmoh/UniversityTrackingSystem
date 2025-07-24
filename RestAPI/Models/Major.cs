using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Major
    {
        public Major()
        {
            Groups = new HashSet<Group>();
            Teachings = new HashSet<Teaching>();
            SubjectsInMajorsLevels = new HashSet<SubjectsInMajorsLevel>();
        }

        [Key]
        [Column("MajorID")]
        public int MajorId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("CollegeID")]
        public int CollegeId { get; set; }

        [ForeignKey(nameof(CollegeId))]
        [InverseProperty("Majors")]
        public virtual College College { get; set; } = null!;
        [InverseProperty(nameof(Group.Major))]
        public virtual ICollection<Group> Groups { get; set; }
 
        [InverseProperty(nameof(Teaching.Major))]
        public virtual ICollection<Teaching> Teachings { get; set; }
        [InverseProperty(nameof(SubjectsInMajorsLevel.Majorr))]
        public virtual ICollection<SubjectsInMajorsLevel> SubjectsInMajorsLevels { get; set; }
       


    }
}
