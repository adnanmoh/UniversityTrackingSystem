using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class SubjectVM
    {
       
        public int SubjectId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool Status { get; set; }
    }
}
