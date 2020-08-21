using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.CreateContatoTelefone
{
    public class CreateContatoTelefoneCommandValidation : AbstractValidator<CreateContatoTelefoneCommand>
    {
        public CreateContatoTelefoneCommandValidation()
        {
                RuleFor(c => c.IdContato)
                  .NotEmpty()
                  .NotNull()
                  .WithMessage("IdContato inválido");

            RuleFor(c => c.TokenUsuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("TokenUsuario inválido");

            RuleFor(c => c.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Telefone inválido");
        }
    }
}
