namespace krugerEvaluacion.Core.Services
{
    using krugerEvaluacion.Core.CustomEntities;
    using krugerEvaluacion.Core.Entities;
    using krugerEvaluacion.Core.Exceptions;
    using krugerEvaluacion.Core.Interfaces;
    using krugerEvaluacion.Core.QueryFilters;
    using Microsoft.Extensions.Options;
    using System.Linq;
    using System.Threading.Tasks;

    public class PropietarioService : IPropietarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PropietarioService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Propietario> GetPropietario(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public PagedList<Propietario> GetPropietario(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var posts = _unitOfWork.PostRepository.GetAll();

            if (filters.UserId != null)
            {
                posts = posts.Where(x => x.UserId == filters.UserId);
            }

            if (filters.Apellido != null)
            {
                posts = posts.Where(x => x.Apellido.ToLower().Contains(filters.Apellido.ToLower()));
            }

            if (filters.Nombre != null)
            {
                posts = posts.Where(x => x.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
            }

            var pagedPosts = PagedList<Propietario>.Create(posts, filters.PageNumber, filters.PageSize);
            return pagedPosts;
        }

        public async Task InsertPropietario(Propietario post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
            {
                throw new BusinessException("User doesn't exist");
            }

            var userPost = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            //if (userPost.Count() < 10)
            //{
            //    var lastPost = userPost.OrderByDescending(x => x.Date).FirstOrDefault();
            //    if ((DateTime.Now - lastPost.Date).TotalDays < 7)
            //    {
            //        throw new BusinessException("You are not able to publish the post");
            //    }
            //}

            //if (post.Description.Contains("Sexo"))
            //{
            //    throw new BusinessException("Content not allowed");
            //}

            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePropietario(Propietario post)
        {
            var existingPost = await _unitOfWork.PostRepository.GetById(post.Id);
            existingPost.Documento = post.Documento;
            existingPost.Nombre = post.Nombre;
            existingPost.Apellido = post.Apellido;
            existingPost.Mail = post.Mail;

            _unitOfWork.PostRepository.Update(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePropietario(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
