using ContactsWebApi.Core.Command;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.CreateContatoEmail
{
    public class CreateContatoEmailCommand : RequestBase, IRequest<CommandReturn>
    {
        public string TokenUsuario { get; private set; }
        public string Email { get; private set; }
        public string IdContato { get; private set; }

        public CreateContatoEmailCommand( string tokenUsuario, CreateContatoEmailInputModel inputModel)
        {
            TokenUsuario = tokenUsuario;
            IdContato = inputModel.IdContato;
            Email = inputModel.Email;
        }

        public override bool EhValido()
        {
            Validation = new CreateContatoEmailCommandValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
