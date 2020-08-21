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

namespace ContactsWebApi.Application_.Commands.CreateContatoEmail
{
    public class CreateContatoEmailCommandHandler : IRequestHandler<CreateContatoEmailCommand, CommandReturn>
    {
        private readonly IGenericRepository<ContatoEmail> _genericRepository;
        private readonly ITokenValidationHelper _tokenValidationHelper;

        public CreateContatoEmailCommandHandler(IGenericRepository<ContatoEmail> genericRepository, ITokenValidationHelper tokenValidationHelper)
        {
            _genericRepository = genericRepository;
            _tokenValidationHelper = tokenValidationHelper;
        }

        public async Task<CommandReturn> Handle(CreateContatoEmailCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new CommandReturn(false, request.Erros(), "");

  

            var iIdUsuarioValidado = _tokenValidationHelper.ValidarUsuario(request.TokenUsuario);

            if (iIdUsuarioValidado == Guid.Empty)
                return new CommandReturn(false, "Usuário inválido");

            if (!Guid.TryParse(request.IdContato, out Guid contatoId))
                return new CommandReturn(false, "Id inválido");

            var contatoEmail = new ContatoEmail
            {
                ContatoId = contatoId,
                Email = request.Email
             };

            var retornoAdicao = await _genericRepository.Adicionar(contatoEmail);

            if (!retornoAdicao)
                return new CommandReturn(false, "Erro ao registrar contatoEmail");

            return retornoAdicao ? new CommandReturn(true, "contatoEmail registrado com sucesso!") : new CommandReturn(false, "Erro ao registrar novo contatoEmail");

        }
    }
}
