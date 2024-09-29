using peryautWebApi.Models;

namespace peryautWebApi.Repositories.Interfaces
{
    public interface IPersonaRepo
    {
        Task<List<Persona>> GetPersonaNotInAutoAndAlive(Guid autoId);
    }
}
