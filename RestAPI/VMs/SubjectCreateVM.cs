namespace RestAPI.VMs
{
    public class SubjectCreateVM
    {
        public int SubjectId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool Status { get; set; } = true;
        public int numberOfLecture { get; set; }

    }
}
