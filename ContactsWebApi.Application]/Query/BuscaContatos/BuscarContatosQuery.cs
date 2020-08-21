using ContactsWebApi.Core.Query;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.BuscaContatos
{
    public class BuscarContatosQuery : RequestBase, IRequest<QueryReturn>
    {
        public string TokenUsuario { get; private set; }

        public BuscarContatosQuery(string tokenUsuario) => TokenUsuario = tokenUsuario;

        public override bool EhValido()
        {
            Validation = new BuscarContatosQueryValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}