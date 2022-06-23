using FluentValidation;
using krugerEvaluacion.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace krugerEvaluacion.Infrastructure.Validators
{
    public class PropietarioValidator: AbstractValidator<PropietarioDto>
    {
        public PropietarioValidator()
        {
            RuleFor(post => post.Documento)
                .NotNull()
                .WithMessage("El documento no puede ser nulo");

            RuleFor(post => post.Nombre)
                .Length(2, 100)
                .WithMessage("La longitud del Nombre debe estar entre 2 y 100 caracteres");

            RuleFor(post => post.Apellido)
                .Length(2, 100)
                .WithMessage("La longitud del Apellido debe estar entre 2 y 100 caracteres");

            RuleFor(post => post.Mail)
                .NotNull()
                .WithMessage("El mail no puede er nulo");

        }
    }
}
