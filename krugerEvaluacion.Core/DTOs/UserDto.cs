using System;
using System.Collections.Generic;
using System.Text;

namespace krugerEvaluacion.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
    }
}
