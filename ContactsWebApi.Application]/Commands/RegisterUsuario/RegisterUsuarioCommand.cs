using ContactsWebApi.Core.Command;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.RegisterUsuario
{
    public class RegisterUsuarioCommand : RequestBase, IRequest<CommandReturn>
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string ConfirmaSenha { get; private set; }

        public RegisterUsuarioCommand(RegisterUsuarioInputModel inputModel)
        {
            Nome = inputModel.Nome;
            Email = inputModel.Email;
            Senha = inputModel.Senha;
            ConfirmaSenha = inputModel.ConfirmaSenha;
        }

        public override bool EhValido()
        {
            Validation = new RegisterUsuarioCommandValidation().Validate(this);
            return Validation.IsValid;
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}