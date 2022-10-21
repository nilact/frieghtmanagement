using FrieghtManagment.Abstraction;
using FrieghtManagment.Models;
using System.Text.Json;

namespace FrieghtManagment
{
    internal class JsonFileReader : IFileReader
    {
        public Dictionary<string, Order> ReadAll()
        {
            var jsonFile = File.ReadAllText("coding-assigment-orders.json");
            var serializationOptions = new System.Text.Json.JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var ordersDictionary = JsonSerializer.Deserialize<Dictionary<string, Order>>(jsonFile,serializationOptions);

            return ordersDictionary;
        }
    }
}
