namespace krugerEvaluacion.Core.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vehiculo : BaseEntity
    {
        [MaxLength(10)]
        public string Placa { get; set; }
        [MaxLength(60)]
        public string Color { get; set; }
        [MaxLength(160)]
        public string Marca { get; set; }
        [ForeignKey("Propietario")]
        public int PropietarioId { get; set; }
        public virtual Propietario Propietario { get; set; }
    }
}
