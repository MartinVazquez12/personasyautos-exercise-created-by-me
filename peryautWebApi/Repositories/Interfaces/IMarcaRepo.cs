using peryautWebApi.Models;

namespace peryautWebApi.Repositories.Interfaces
{
    public interface IMarcaRepo
    {
        Task<List<Marca>> GetAllMarcas();
    }
}
