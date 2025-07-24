namespace RestAPI.VMs
{
    public class AttachmentVM
    {
       
        public int AttachmentId { get; set; }
        public byte[] File { get; set; } = null!;
        public string Note { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;
        public int YearId { get; set; }        
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
