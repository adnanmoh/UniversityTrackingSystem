namespace RestAPI.VMs
{
    public class GradeVM
    {
        public int GradeId { get; set; }
       
        public int SubjectId { get; set; }
       
        public int StudentId { get; set; }
       
        public int TeacherId { get; set; }
        
        public int YearId { get; set; }

        public decimal? Attendance { get; set; }

        public decimal? Exam { get; set; }

        public decimal? participation { get; set; }

        public bool IsPosted { get; set; }
    }
}
