namespace krugerEvaluacion.Core.Services
{
    using krugerEvaluacion.Core.CustomEntities;
    using krugerEvaluacion.Core.Entities;
    using krugerEvaluacion.Core.Exceptions;
    using krugerEvaluacion.Core.Interfaces;
    using krugerEvaluacion.Core.QueryFilters;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task Add(User entity)
        {
            await _unitOfWork.UserRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
