using krugerEvaluacion.Core.Entities;
using System.Threading.Tasks;

namespace krugerEvaluacion.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
