using ContactsWebApi.Application_.Helpers;
using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Query;
using ContactsWebApi.Core.Repository;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsWebApi.Application_.Query.BuscaContatos
{
    public class BuscarContatosQueryHandler : IRequestHandler<BuscarContatosQuery, QueryReturn>
    {
        private readonly IGenericRepository<Contato> _genericRepository;
        private readonly ITokenValidationHelper _tokenValidationHelper;

        public BuscarContatosQueryHandler(IGenericRepository<Contato> genericRepository, ITokenValidationHelper tokenValidationHelper)
        {
            _genericRepository = genericRepository;
            _tokenValidationHelper = tokenValidationHelper;
        }

        public async Task<QueryReturn> Handle(BuscarContatosQuery request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new QueryReturn(false, request.Erros(), "");

            var iIdUsuarioValidado = _tokenValidationHelper.ValidarUsuario(request.TokenUsuario);

            if (iIdUsuarioValidado == Guid.Empty)
                return new QueryReturn(false, "Usuário inválido");


            var listaContatos = await _genericRepository.Buscar(iIdUsuarioValidado);

            if (listaContatos == null)
                new QueryReturn(false, "Erro ao buscar os contatos");

            var listaARetornar = listaContatos.Select(c => new BuscarContatoViewModel
            {
                IdContato = c.Id,
                Nome = c.Nome,
                DataCadastro = c.DataCadastro,
                Nota = c.Nota
            }).OrderBy(e => e.Nome);

            return new QueryReturn(true, "Busca realizada com sucesso", listaARetornar);
        }
    }
}
