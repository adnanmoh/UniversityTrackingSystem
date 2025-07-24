namespace RestAPI.VMs
{
    public class SearchTeacherSchedule
    {
        public int? ScheduleId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? TeacherId { get; set; }
        public int? YearId { get; set; }
        public int? TermId { get; set; }

    }
}
