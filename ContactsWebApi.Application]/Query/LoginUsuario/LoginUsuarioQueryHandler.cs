using ContactsWebApi.Application_.Helpers;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Query;
using ContactsWebApi.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsWebApi.Application_.Query.LoginUsuario
{
    public class LoginUsuarioQueryHandler : IRequestHandler<LoginUsuarioQuery, QueryReturn>
    {
        private readonly IUserRepository _userRepository;

        public LoginUsuarioQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<QueryReturn> Handle(LoginUsuarioQuery request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new QueryReturn(false, request.Erros(), "");


            var retornoBusca = await _userRepository.BuscaIdUsuario(request.Email, request.Senha);

            
            return retornoBusca != Guid.Empty ? new QueryReturn(true,"Login realizado com sucesso",new { Token = retornoBusca }) :  new QueryReturn(false, request.Erros(), "Email e ou senha inválidos, tente novamente");
        }
    }
}
