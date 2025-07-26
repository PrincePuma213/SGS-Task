using TestWpfApp.Models;

namespace TestWpfApp.Data
{
    public interface IDataProvider
    {
        List<City> GetCities();
        List<Workshop> GetWorkshopsByCity(int cityId);
        List<Employee> GetEmployeesByWorkshop(int workshopId);
        List<Brigade> GetBrigades();
    }
}
