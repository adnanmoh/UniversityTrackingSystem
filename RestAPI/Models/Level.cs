using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Level
    {
        public Level()
        {
            Groups = new HashSet<Group>();
            SubjectsInMajorsLevels = new HashSet<SubjectsInMajorsLevel>();
        }

        [Key]
        [Column("LevelID")]
        public int LevelId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Group.Level))]
        public virtual ICollection<Group> Groups { get; set; }

        [InverseProperty(nameof(SubjectsInMajorsLevel.Levell))]
        public virtual ICollection<SubjectsInMajorsLevel> SubjectsInMajorsLevels { get; set; }
    }
}
