using ContactsWebApi.Application_.Helpers;
using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Query;
using ContactsWebApi.Core.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsWebApi.Application_.Query.BuscarContato
{
    public class BuscarContatoQueryHandler : IRequestHandler<BuscarContatoQuery, QueryReturn>
    {
        private readonly ITokenValidationHelper _tokenValidationHelper;
        private readonly IGenericRepository<Contato> _genericRepository;

        public BuscarContatoQueryHandler(ITokenValidationHelper tokenValidationHelper, IGenericRepository<Contato> genericRepository)
        {
            _tokenValidationHelper = tokenValidationHelper;
            _genericRepository = genericRepository;
        }

        public async Task<QueryReturn> Handle(BuscarContatoQuery request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new QueryReturn(false, request.Erros(), "");

            if (!Guid.TryParse(request.ContatoId, out Guid idContato))
                return new QueryReturn(false, "Id inválido");

            var iIdUsuarioValidado = _tokenValidationHelper.ValidarUsuario(request.TokenUsuario);

            if (iIdUsuarioValidado == Guid.Empty)
                return new QueryReturn(false, "Usuário inválido");

            var contato = await _genericRepository.BuscarPorId(idContato);
    
            return contato != null?
                new QueryReturn(true, "Busca realizada com sucesso", contato) :
                new QueryReturn(false, "Erro ao buscar");
        }
    }
}
