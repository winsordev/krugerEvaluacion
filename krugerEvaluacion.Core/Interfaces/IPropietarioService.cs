namespace krugerEvaluacion.Core.Interfaces
{
    using krugerEvaluacion.Core.CustomEntities;
    using krugerEvaluacion.Core.Entities;
    using krugerEvaluacion.Core.QueryFilters;
    using System.Threading.Tasks;

    public interface IPropietarioService
    {
        PagedList<Propietario> GetPropietario(PostQueryFilter filters);

        Task<Propietario> GetPropietario(int id);

        Task InsertPropietario(Propietario post);

        Task<bool> UpdatePropietario(Propietario post);

        Task<bool> DeletePropietario(int id);
    }
}
