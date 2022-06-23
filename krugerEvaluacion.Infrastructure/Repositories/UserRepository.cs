namespace krugerEvaluacion.Infrastructure.Repositories
{
    using krugerEvaluacion.Core.Entities;
    using krugerEvaluacion.Core.Interfaces;
    using krugerEvaluacion.Infrastructure.Data;
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ParqueaderoContext context) : base(context) { }

    }
}
