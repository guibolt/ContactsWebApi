using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.BuscarContato
{
    public class BuscarContatoQueryValidation : AbstractValidator<BuscarContatoQuery>
    {
        public BuscarContatoQueryValidation()
        {
                     RuleFor(c => c.TokenUsuario)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Token Usuario inválido");

                    RuleFor(c => c.ContatoId)
               .NotEmpty()
               .NotNull()
               .WithMessage("ContatoId inválido");
        }
    }
}
