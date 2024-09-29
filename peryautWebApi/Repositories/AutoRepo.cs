using Microsoft.EntityFrameworkCore;
using peryautWebApi.Models;
using peryautWebApi.Repositories.Interfaces;

namespace peryautWebApi.Repositories
{
    public class AutoRepo : IAutoRepo
    {
        private readonly PersonasyautosContext _context;

        public AutoRepo(PersonasyautosContext context)
        {
            _context = context;
        }

        public async Task<Auto> AddAuto(Auto auto)
        {
            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();
            return auto;
        }

        public async Task<DueniosConAuto> AddDuenioToAuto(DueniosConAuto dueniosConAuto)
        {
            await _context.DueniosConAutos.AddAsync(dueniosConAuto);
            await _context.SaveChangesAsync();
            return dueniosConAuto;
        }

        public async Task<bool> ExisteAuto(string nombre, string color)
        {
            var existeAuto = await _context.Autos
                .AnyAsync(x=> x.Nombre.Equals(nombre) && x.Color.Equals(color));
            return existeAuto;
        }

        public async Task<List<Auto>> GetAllAutosActives()
        {
            var autos = await _context.Autos
                .Include(x => x.IdMarcaNavigation)
                .Where(x => x.Activo)
                .ToListAsync();
            return autos;
        }
    }
}
