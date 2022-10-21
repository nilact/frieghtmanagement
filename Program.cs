// See https://aka.ms/new-console-template for more information
using FrieghtManagment;
using FrieghtManagment.Abstraction;
using FrieghtManagment.Models;
using FrieghtManagment.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IFileReader, JsonFileReader>();
            services.AddScoped<FlightScheduleFactory>();
        })
        .Build();

        DisplayAndRead((FlightScheduleFactory)host.Services.GetRequiredService(typeof(FlightScheduleFactory)));

        host.Run();


    }
    static void DisplayAndRead(FlightScheduleFactory flightScheduleFactory)
    {
        Console.Clear();
        
        Console.WriteLine("=======Transport.ly Freight Management=======");
        Console.WriteLine("\nDefault flight schedule \n");
        var defaultFlightScheduleInstance = flightScheduleFactory.GetFlightTypeScheduelInstance(FlightTypeSchedule.DefaultFlight);
        defaultFlightScheduleInstance.DisplayFlightSchedule();
        Console.WriteLine("\nLoaded orders flight schedule \n");
        var loadedOrderFlightScheduleInstance = flightScheduleFactory.GetFlightTypeScheduelInstance(FlightTypeSchedule.LoadedFlight);
        loadedOrderFlightScheduleInstance.DisplayFlightSchedule();
    } 

}