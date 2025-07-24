using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class StudentScheduleVM
    {

        public int ScheduleId { get; set; }
        public byte[]? Sfile { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public int YearId { get; set; }
        public int TermId { get; set; }
        public int GroupId { get; set; }
        
    }
}
