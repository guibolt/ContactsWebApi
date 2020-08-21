using ContactsWebApi.Core.Command;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Commands.CreateContato
{
    public class CreateContatoCommand : RequestBase, IRequest<CommandReturn>
    {
        public string Nome { get; private set; }
        public string Nota { get; private set; }
        public string TokenUsuario { get; private set; }

        public CreateContatoCommand(CreateContatoInputModel inputModel, string tokenUsuario)
        {
            Nome = inputModel.Nome;
            Nota = inputModel.Nota;
            TokenUsuario = tokenUsuario; 
        }

        public override bool EhValido()
        {
            Validation = new CreateContatoCommandValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
