using krugerEvaluacion.Core.Entities;
using krugerEvaluacion.Core.Interfaces;
using krugerEvaluacion.Infrastructure.Data;
using System.Threading.Tasks;

namespace krugerEvaluacion.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParqueaderoContext _context;
        private readonly IPropietarioRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Vehiculo> _vehiculoRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(ParqueaderoContext context)
        {
            _context = context;
        }

        public IPropietarioRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public IRepository<Vehiculo> VehiculoRepository => _vehiculoRepository ?? new BaseRepository<Vehiculo>(_context);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

