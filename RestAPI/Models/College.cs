using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class College
    {
        public College()
        {
            Majors = new HashSet<Major>();
        }

        [Key]
        [Column("CollegeID")]
        public int CollegeId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Location { get; set; } = null!;

        [InverseProperty(nameof(Major.College))]
        public virtual ICollection<Major> Majors { get; set; }
       
    }
}
