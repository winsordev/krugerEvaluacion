using System;

namespace krugerEvaluacion.Core.QueryFilters
{
    public class PostQueryFilter
    {
        public int? UserId { get; set; }

        public DateTime? Date { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
