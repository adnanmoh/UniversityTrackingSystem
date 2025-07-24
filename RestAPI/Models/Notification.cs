using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Notification
    {
        [Key]
        [Column("NotificationID")]
        public int NotificationId { get; set; }
        [Column(TypeName = "text")]
        public string? Text { get; set; }
        [Column(TypeName = "text")]
        public string Title { get; set; } = null!;
        [Column("SenderID")]
        public int? SenderId { get; set; }
        [Column("ReceiverID")]
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public int NotificationTypeId { get; set; }

        [ForeignKey(nameof(NotificationTypeId))]
        [InverseProperty("Notifications")]
        public virtual NotificationType NotificationType { get; set; } = null!;
    }
}
