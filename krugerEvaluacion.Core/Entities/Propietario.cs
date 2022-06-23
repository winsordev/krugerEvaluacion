namespace krugerEvaluacion.Core.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Propietario : BaseEntity
    {
        [MaxLength(50)]
        public string Documento { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellido { get; set; }
        [MaxLength(100)]
        public string Mail { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
