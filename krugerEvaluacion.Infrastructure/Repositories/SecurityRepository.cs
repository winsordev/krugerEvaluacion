using Microsoft.EntityFrameworkCore;
using krugerEvaluacion.Core.Entities;
using krugerEvaluacion.Core.Interfaces;
using krugerEvaluacion.Infrastructure.Data;
using System.Threading.Tasks;

namespace krugerEvaluacion.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(ParqueaderoContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == login.User);
        }
    }
}
