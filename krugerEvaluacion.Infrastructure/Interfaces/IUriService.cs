using krugerEvaluacion.Core.QueryFilters;
using System;

namespace krugerEvaluacion.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
