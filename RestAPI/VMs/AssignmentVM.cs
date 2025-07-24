using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.VMs
{
    public class AssignmentVM
    {
   
        public int AssignmentId { get; set; }
        public int Number { get; set; }
        public string? Qtitle { get; set; }
        public string? Qtext { get; set; }
        public byte[]? Qfile { get; set; }
        public decimal MaxGrade { get; set; }
        public DateTime DateTime { get; set; }
        public int TeacherId { get; set; }
        public int YearId { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
    }
}
