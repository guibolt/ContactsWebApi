using ContactsWebApi.Application_.Commands.CreateContato;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.CreateContatoEmail
{
    public class CreateContatoEmailCommandValidation : AbstractValidator<CreateContatoEmailCommand>
    {
        public CreateContatoEmailCommandValidation()
        {
                  RuleFor(c => c.Email)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Email inválido");

                RuleFor(c => c.IdContato)
               .NotEmpty()
               .NotNull()
               .WithMessage("IdContato inválido");

            RuleFor(c => c.TokenUsuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("TokenUsuario inválido");
        }
    }
}
