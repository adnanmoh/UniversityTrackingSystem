using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Interfaces
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<ICollection<Notification>> GetNotificationsByReceiverIDAndIsReadFalse(int receiverID);

    }
}
