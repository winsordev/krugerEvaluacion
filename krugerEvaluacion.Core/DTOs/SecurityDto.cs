﻿namespace krugerEvaluacion.Core.DTOs
{
    using krugerEvaluacion.Core.Entities;
    using krugerEvaluacion.Core.Enumerations;
    public class SecurityDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleType? Role { get; set; }
    }
}
