using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.LoginUsuario
{
    public class LoginUsuarioQueryValidation : AbstractValidator<LoginUsuarioQuery>
    {
        public LoginUsuarioQueryValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(c => c.Senha)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email inválido");

            RuleFor(c => c.Senha)
                .MinimumLength(6)
                .WithMessage("Senha inválida");
        }
    }
}