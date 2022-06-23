using krugerEvaluacion.Core.Entities;
using System.Threading.Tasks;

namespace krugerEvaluacion.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
