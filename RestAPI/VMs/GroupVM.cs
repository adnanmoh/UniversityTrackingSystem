using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class GroupVM
    {
        
        public int GroupId { get; set; }
        
        public string Name { get; set; } = null!;
        
        public int YearId { get; set; }
       
        public int LevelId { get; set; }
       
        public int MajorId { get; set; }
       
        public int? ParentGroupId { get; set; }
    }
}
