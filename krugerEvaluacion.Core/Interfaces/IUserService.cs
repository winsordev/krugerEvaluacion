namespace krugerEvaluacion.Core.Interfaces
{
    using krugerEvaluacion.Core.Entities;
    using System.Threading.Tasks;
    public interface IUserService
    {
        Task Add(User entity);
    }
}
