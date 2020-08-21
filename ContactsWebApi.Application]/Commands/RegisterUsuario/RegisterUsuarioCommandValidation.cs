using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.RegisterUsuario
{
    public class RegisterUsuarioCommandValidation : AbstractValidator<RegisterUsuarioCommand>
    {
        public RegisterUsuarioCommandValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome inválido");

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(c => c.Senha)
                .NotEmpty()
                .NotNull()
                .WithMessage("Senha inválido");

            RuleFor(c => c.Senha)
                .MinimumLength(6)
                .WithMessage("Senha deve ter no mínimo 6 caracteres");

            RuleFor(c => c.ConfirmaSenha)
                .Equal(p => p.Senha)
                .WithMessage("Confirma senha inválida");
        }
    }
}
