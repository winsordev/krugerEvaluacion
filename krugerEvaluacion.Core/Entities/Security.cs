namespace krugerEvaluacion.Core.Entities
{
    using krugerEvaluacion.Core.Enumerations;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Security : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public string Password { get; set; }

        public RoleType Role { get; set; }
    }
}
