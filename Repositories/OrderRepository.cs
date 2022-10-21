using FrieghtManagment.Abstraction;
using FrieghtManagment.Models;

namespace FrieghtManagment.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly IFileReader _fileReader;

        public OrderRepository(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IList<Order> GetOrders()
        {

            var ordersDictionary = _fileReader.ReadAll();

            return ordersDictionary.Select(
                    x => new Order()
                    {
                        Ordernumber = x.Key,
                        Destination = x.Value.Destination.ToString(),
                        Priority = int.Parse(x.Key.Substring(x.Key.LastIndexOf('-') + 1))
                    }).ToList();

        }
    }
}
