using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using ContactsWebApi.Infrastructure.EntityContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWebApi.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly ContactsContext _contactsContext;

        public UserRepository(ContactsContext contactsContext) => _contactsContext = contactsContext;

        public async Task<bool> AdicionarUsuario(Usuario item)
        {
            try
            {

                var emailRegistrado = await _contactsContext.Usuarios.AnyAsync(e => e.Email == item.Email);

                if (emailRegistrado)
                    return false;

                await _contactsContext.Usuarios.AddAsync(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Guid> BuscaIdUsuario(string email, string senha)
        {
            try
            {

                var usuario = await _contactsContext.Usuarios.Where(c => c.Email == email).FirstOrDefaultAsync();

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                if (usuario == null)
                    return Guid.Empty;

                return usuario.Senha == senha ? usuario.Id : Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
