using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Repository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly UAppContext context;

        public NotificationRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        

        public async Task<ICollection<Notification>> GetNotificationsByReceiverIDAndIsReadFalse(int receiverID)
        {
            try
            {

                List<Notification> res =await context.Notifications.Where(x => x.ReceiverId == receiverID && x.IsRead == false).ToListAsync();
                return res;
            }
            catch
            {

                return default;
            }
        }
    }
}
