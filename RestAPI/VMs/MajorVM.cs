using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class MajorVM
    {
        [Key]
        [Column("MajorID")]
        public int MajorId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("CollegeID")]
        public int CollegeId { get; set; }
    }
}
