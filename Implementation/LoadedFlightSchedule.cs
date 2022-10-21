using FrieghtManagment.Abstraction;
using FrieghtManagment.Models;
using FrieghtManagment.Repositories;

namespace FrieghtManagment
{
    internal class LoadedFlightSchedule : IFlightSchedule
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IScheduleRepository _scheduleRepository;
        public LoadedFlightSchedule(IOrderRepository orderRepository, IScheduleRepository scheduleRepository)
        {
            _orderRepository = orderRepository;
            _scheduleRepository = scheduleRepository;
        }
        public void DisplayFlightSchedule()
        {
            var scheduledFlights = _scheduleRepository.GetSchedules();
            var orders = _orderRepository.GetOrders();
            List<Order> loadedOrders = new List<Order>();

            foreach (var flight in scheduledFlights)
            {
                var ordersToBeLoaded = orders.Where(x => x.IsNotLoaded() && x.Destination == flight.Destination).OrderBy(x => x.Priority).Take(20).ToList();

                if(ordersToBeLoaded.Any())
                    Console.WriteLine($"\nLoaded Orders for destination {flight.Destination} for flightnumber {flight.FlightNumber} is {ordersToBeLoaded.Count}\n");

                foreach (var order in ordersToBeLoaded)
                {
                    order.Schedule = flight;

                    Console.WriteLine($"order:{order.Ordernumber},flightnumber:{order.Schedule.FlightNumber}, departure:{order.Schedule.Source}, arrival:{order.Schedule.Destination}, day:{order.Schedule.Day}");

                    loadedOrders.Add(order);
                }
            }          

            Console.WriteLine("\nUnloaded Orders:\n");

            var unloadedOrders = orders.Except(loadedOrders);

            foreach (var item in unloadedOrders)
            {
                Console.WriteLine($"order:{item.Ordernumber}, destination:{item.Destination}, flightnumber:not scheduled");
            }

        }
    }
}
