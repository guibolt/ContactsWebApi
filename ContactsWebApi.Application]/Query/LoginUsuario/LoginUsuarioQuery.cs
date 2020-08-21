using ContactsWebApi.Core.Query;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.LoginUsuario
{
    public class LoginUsuarioQuery : RequestBase, IRequest<QueryReturn>
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public LoginUsuarioQuery(LoginQueryInputModel inputModel)
        {
            Email = inputModel.Email;
            Senha = inputModel.Senha;
        }

        public override bool EhValido()
        {
            Validation = new LoginUsuarioQueryValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
