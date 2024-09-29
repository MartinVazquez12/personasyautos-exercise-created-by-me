using peryautWebApi.Models;

namespace peryautWebApi.Repositories.Interfaces
{
    public interface IAutoRepo
    {
        Task<Auto> AddAuto(Auto auto);
        Task<List<Auto>> GetAllAutosActives();
        Task<DueniosConAuto> AddDuenioToAuto(DueniosConAuto dueniosConAuto);
        Task<bool> ExisteAuto(string nombre, string color);
    }
}
