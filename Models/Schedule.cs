namespace FrieghtManagment.Models
{
    internal class Schedule
    {

        //use auto properties
        public int FlightNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Day { get; set; }
        public bool IsLoaded { get; set; }

        public override string ToString()
        {
            //use string interpolation
            return $"{FlightNumber}. Source: {Source},  Destination: {Destination}, Day: {Day}";
        }

    }
}
