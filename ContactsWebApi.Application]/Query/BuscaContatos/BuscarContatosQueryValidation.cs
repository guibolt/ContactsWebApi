using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.BuscaContatos
{
    public class BuscarContatosQueryValidation : AbstractValidator<BuscarContatosQuery>
    {
        public BuscarContatosQueryValidation()

         => RuleFor(c => c.TokenUsuario)
         .NotEmpty()
         .NotNull()
         .WithMessage("Token Usuario inválido");
    }
}
