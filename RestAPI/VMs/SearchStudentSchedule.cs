namespace RestAPI.VMs
{
    public class SearchStudentSchedule
    {
        public int? ScheduleId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? YearId { get; set; }
        public int? GroupId { get; set; }
        public int? TermId { get; set; }
    }
}
