using ContactsWebApi.Core.Command;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.CreateContatoTelefone
{
    public class CreateContatoTelefoneCommand : RequestBase, IRequest<CommandReturn>
    {
        public string TokenUsuario { get; private set; }
        public string IdContato { get; private set; }
        public string Telefone { get; private set; }

        public CreateContatoTelefoneCommand(CreateContatoTelefoneInputModel inputModel, string tokenUsuario)
        {
            TokenUsuario = tokenUsuario;
            IdContato = inputModel.IdContato;
            Telefone = inputModel.Telefone;
        }

        public override bool EhValido()
        {
            Validation = new CreateContatoTelefoneCommandValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
