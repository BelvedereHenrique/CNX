using System.Threading.Tasks;

namespace CNX.Contracts.Interfaces
{
    public interface IWeatherMapsService
    {
        Task<int> GetHometownTemperature(string userHometown);
    }
}
