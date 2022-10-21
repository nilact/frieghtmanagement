using FrieghtManagment.Models;

namespace FrieghtManagment.Abstraction
{
    internal interface IOrderRepository
    {
        IList<Order> GetOrders();
    }
}
