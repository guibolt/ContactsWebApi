using ContactsWebApi.Core.Command;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsWebApi.Application_.Commands.RegisterUsuario
{
    public class RegisterUsuarioCommandHandler : IRequestHandler<RegisterUsuarioCommand, CommandReturn>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUsuarioCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<CommandReturn> Handle(RegisterUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new CommandReturn(false, request.Erros(), "");


            var usuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha
            };

            var retornoAdicao = await _userRepository.AdicionarUsuario(usuario);

            if (!retornoAdicao)
                return new CommandReturn(false, "Erro ao registrar usuário");

            return retornoAdicao ? new CommandReturn(true, "usuário registrado com sucesso!") : new CommandReturn(false, "Erro ao registrar novo usuário");

        }
    }
}
