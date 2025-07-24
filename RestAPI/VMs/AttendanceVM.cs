using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class AttendanceVM
    {

        public int AttendanceId { get; set; }

        public string State { get; set; } = null!;
        public DateTime DateTime { get; set; }

        public string? Reason { get; set; }
        public byte[]? Rfile { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public int LectureId { get; set; }
      
    }
}
