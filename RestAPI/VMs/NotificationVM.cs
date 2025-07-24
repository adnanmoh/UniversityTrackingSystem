namespace RestAPI.VMs
{
    public class NotificationVM
    {
        public int NotificationId { get; set; }
       
        public string? Text { get; set; }
        
        public string Title { get; set; } = null!;
        
        public int? SenderId { get; set; }
        
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
