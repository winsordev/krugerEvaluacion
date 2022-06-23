using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace krugerEvaluacion.Core.Entities
{
    public class Registro : BaseEntity
    {
        public DateTime Ingreso { get; set; }
        public DateTime Salida { get; set; }
        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
