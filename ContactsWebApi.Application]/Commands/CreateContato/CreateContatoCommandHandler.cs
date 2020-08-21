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

namespace ContactsWebApi.Application_.Commands.CreateContato
{
    public class CreateContatoCommandHandler : IRequestHandler<CreateContatoCommand, CommandReturn>
    {
        private readonly IGenericRepository<Contato> _genericRepository;
        private readonly ITokenValidationHelper _tokenValidationHelper;

        public CreateContatoCommandHandler(IGenericRepository<Contato> genericRepository, ITokenValidationHelper tokenValidationHelper)
        {
            _genericRepository = genericRepository;
            _tokenValidationHelper = tokenValidationHelper;
        }

        public async Task<CommandReturn> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new CommandReturn(false, request.Erros(), "");


            var iIdUsuarioValidado = _tokenValidationHelper.ValidarUsuario(request.TokenUsuario);

            if(iIdUsuarioValidado == Guid.Empty)
                return new CommandReturn(false,  "Usuário inválido");

            var contato = new Contato 
            { 
                Nome = request.Nome, 
                Nota = request.Nota,
                UsuarioId = iIdUsuarioValidado
            };


            var retornoAdicao = await _genericRepository.Adicionar(contato);

            if (!retornoAdicao)
                return new CommandReturn(false, "Erro ao registrar contato");

            return retornoAdicao ? new CommandReturn(true, "contato registrado com sucesso!") : new CommandReturn(false, "Erro ao registrar novo contato");

        }

    }
}