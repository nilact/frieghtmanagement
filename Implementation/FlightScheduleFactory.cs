using FrieghtManagment.Abstraction;
using FrieghtManagment.Models;
using FrieghtManagment.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrieghtManagment
{
    internal class FlightScheduleFactory
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IOrderRepository _orderRepository;
        private readonly IScheduleRepository _scheduledRepository;
        public FlightScheduleFactory(IServiceProvider serviceProvider, IOrderRepository orderRepository, IScheduleRepository scheduleRepository)
        {
            _serviceProvider = serviceProvider;
            _orderRepository = orderRepository;
            _scheduledRepository = scheduleRepository;
        }

        public IFlightSchedule GetFlightTypeScheduelInstance(FlightTypeSchedule flightTypeSchedule)
        {
            if (flightTypeSchedule == FlightTypeSchedule.DefaultFlight)
                return ActivatorUtilities.CreateInstance<DefaultFlightSchedule>(_serviceProvider, _scheduledRepository);

            return ActivatorUtilities.CreateInstance<LoadedFlightSchedule>(_serviceProvider, _orderRepository, _scheduledRepository); ;


        }


    }
}
