using Microsoft.EntityFrameworkCore;
using peryautWebApi.Models;
using peryautWebApi.Repositories.Interfaces;

namespace peryautWebApi.Repositories
{
    public class PersonaRepo : IPersonaRepo
    {
        private readonly PersonasyautosContext _context;

        public PersonaRepo(PersonasyautosContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetPersonaNotInAutoAndAlive(Guid autoId)
        {
            var personaInAuto = _context.DueniosConAutos
                .Where(x => x.IdAuto == autoId).Select(x => x.IdDuenio);

            var personaNotAuto = await _context.Personas
                .Where(x => !personaInAuto.Contains(x.Id) && x.Vivo)
                .ToListAsync();

            return personaNotAuto;
        }
    }
}
