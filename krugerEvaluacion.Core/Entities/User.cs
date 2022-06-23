namespace krugerEvaluacion.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class User : BaseEntity
    {
        public User()
        {
            //Comments = new HashSet<Comment>();
            Propietarios = new HashSet<Propietario>();
        }

        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellido { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(15)]
        public string Telephone { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Propietario> Propietarios { get; set; }
        //public virtual ICollection<Post> Posts { get; set; }
    }
}
