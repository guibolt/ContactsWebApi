using ContactsWebApi.Core.Query;
using ContactsWebApi.Core.Request;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.BuscarContato
{
    public class BuscarContatoQuery : RequestBase, IRequest<QueryReturn>
    {
        public string TokenUsuario { get; private set; }
        public string ContatoId { get; private set; }

        public BuscarContatoQuery(string tokenUsuario, string contatoId)
        {
            TokenUsuario = tokenUsuario;
            ContatoId = contatoId;
        }

        public override bool EhValido()
        {
            Validation = new BuscarContatoQueryValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
