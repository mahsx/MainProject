using System.Linq.Expressions;
using batch3.Models;

namespace batch3.Repositories
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentId(int id, string sessionId ,string paymentIntentId);
    }
}