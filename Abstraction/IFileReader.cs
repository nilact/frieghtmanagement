using FrieghtManagment.Models;

namespace FrieghtManagment.Abstraction
{
    internal interface IFileReader
    {
        Dictionary<string, Order> ReadAll();
    }
}
