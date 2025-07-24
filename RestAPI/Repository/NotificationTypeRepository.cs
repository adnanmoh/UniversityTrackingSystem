using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class NotificationTypeRepository : GenericRepository<NotificationType> , INotificationTypeRepository
    {
        private readonly UAppContext context;

        public NotificationTypeRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }
    }
}
