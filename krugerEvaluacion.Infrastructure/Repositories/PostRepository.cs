using krugerEvaluacion.Core.Entities;
using krugerEvaluacion.Core.Interfaces;
using krugerEvaluacion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace krugerEvaluacion.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Propietario>, IPropietarioRepository
    {
        public PostRepository(ParqueaderoContext context) : base(context) { }

        public async Task<IEnumerable<Propietario>> GetPostsByUser(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}