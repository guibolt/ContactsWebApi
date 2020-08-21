using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.CreateContato
{
    public class CreateContatoCommandValidation : AbstractValidator<CreateContatoCommand>
    {
        public CreateContatoCommandValidation()
        {

                 RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome inválido");  

            RuleFor(c => c.TokenUsuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("TokenUsuario inválido");

        }
    }
}
