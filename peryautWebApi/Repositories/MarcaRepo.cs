using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using peryautWebApi.Models;
using peryautWebApi.Repositories.Interfaces;

namespace peryautWebApi.Repositories
{
    public class MarcaRepo : IMarcaRepo
    {
        private readonly PersonasyautosContext _context;

        public MarcaRepo(PersonasyautosContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> GetAllMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }
    }
}
