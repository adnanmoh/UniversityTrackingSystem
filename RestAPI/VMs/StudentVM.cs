using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class StudentVM
    {

        public int StudentId { get; set; }
   
        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string IdNumber { get; set; } = null!;

        public string Password { get; set; } = null!;
  
        public int GroupId { get; set; }
    }
}
