using ContactsWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWebApi.Core.Repository
{
    public interface IUserRepository
    {
        Task<bool> AdicionarUsuario(Usuario usuario);
        Task<Guid> BuscaIdUsuario(string email, string senha);

    }
}
