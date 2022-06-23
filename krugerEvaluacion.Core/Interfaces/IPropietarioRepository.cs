using krugerEvaluacion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace krugerEvaluacion.Core.Interfaces
{
    public interface IPropietarioRepository : IRepository<Propietario>
    {
        Task<IEnumerable<Propietario>> GetPostsByUser(int userId);
    }
}
