using krugerEvaluacion.Core.Entities;
using System;
using System.Threading.Tasks;

namespace krugerEvaluacion.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPropietarioRepository PostRepository { get; }

        IUserRepository UserRepository { get; }

        //IRepository<Comment> CommentRepository { get; }

        ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
