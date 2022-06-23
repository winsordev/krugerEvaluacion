namespace krugerEvaluacion.Core.Interfaces
{
    using krugerEvaluacion.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IUserRepository: IRepository<User>
    {
        //Task RegisterUser(User entity);
    }
}
