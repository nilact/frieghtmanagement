using FrieghtManagment.Abstraction;
using FrieghtManagment.Repositories;

namespace FrieghtManagment
{
    internal class DefaultFlightSchedule : IFlightSchedule
    {
        private readonly IScheduleRepository _scheduleRepository;
        public DefaultFlightSchedule(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public void DisplayFlightSchedule()
        {
            var scheduledFlights = _scheduleRepository.GetSchedules();

            foreach (var scheduledFlight in scheduledFlights)
            {
                Console.WriteLine($"Flight:{scheduledFlight.FlightNumber}, Departure:{scheduledFlight.Source}, Arrival:{scheduledFlight.Destination}, Day:{scheduledFlight.Day}");
            }
        }
    }
}
