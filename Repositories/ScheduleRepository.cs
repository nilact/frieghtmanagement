using FrieghtManagment.Models;

namespace FrieghtManagment.Repositories
{
    internal class ScheduleRepository : IScheduleRepository
    {
        public IList<Schedule> GetSchedules()
        {
            //use implicitly typed variables
            var flightNo = 1;
            var day = 1;
            var schedules = new List<Schedule>();

            schedules.Add(new Schedule { FlightNumber = flightNo++, Source = "YUL", Destination = "YYZ", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Source = "YUL", Destination = "YYC", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Source = "YUL", Destination = "YVR", Day = day, IsLoaded = false });

            day++;
            schedules.Add(new Schedule { FlightNumber = flightNo++, Source = "YUL", Destination = "YYZ", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Source = "YUL", Destination = "YYC", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Source = "YUL", Destination = "YVR", Day = day, IsLoaded = false });

            return schedules;
        }
    }
}
