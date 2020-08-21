using ContactsWebApi.Application_.Commands.CreateContatoEmail;
using ContactsWebApi.Application_.Helpers;
using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Core.Command;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsWebApi.Application_.Commands.CreateContatoTelefone
{
    public class CreateContatoTelefoneCommandHandler : IRequestHandler<CreateContatoTelefoneCommand, CommandReturn>
    {
        private readonly IGenericRepository<ContatoTelefone> _genericRepository;
        private readonly ITokenValidationHelper _tokenValidationHelper;

        public CreateContatoTelefoneCommandHandler(IGenericRepository<ContatoTelefone> genericRepository, ITokenValidationHelper tokenValidationHelper)
        {
            _genericRepository = genericRepository;
            _tokenValidationHelper = tokenValidationHelper;
        }

        public async Task<CommandReturn> Handle(CreateContatoTelefoneCommand request, CancellationToken cancellationToken)
        {

            if (!request.EhValido())
                return new CommandReturn(false, request.Erros(), "");

            var iIdUsuarioValidado = _tokenValidationHelper.ValidarUsuario(request.TokenUsuario);

            if (iIdUsuarioValidado == Guid.Empty)
                return new CommandReturn(false, "Usuário inválido");

            if (!Guid.TryParse(request.IdContato, out Guid contatoId))
                return new CommandReturn(false, "Id inválido");

            var contatoTelefone = new ContatoTelefone
            {
                ContatoId = contatoId,
                TeleFone = request.Telefone
            };

            var retornoAdicao = await _genericRepository.Adicionar(contatoTelefone);

            if (!retornoAdicao)
                return new CommandReturn(false, "Erro ao registrar contatoTelefone");

            return retornoAdicao ? new CommandReturn(true, "contatoTelefone registrado com sucesso!") : new CommandReturn(false, "Erro ao registrar novo contatoTelefone");

        }
    }

}
