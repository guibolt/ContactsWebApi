using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using ContactsWebApi.Infrastructure.EntityContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWebApi.Infrastructure.Repositories
{
    public class ContactsRepository : IGenericRepository<Contato>
    {
        private readonly ContactsContext _contactsContext;

        public ContactsRepository(ContactsContext contactsContext) => _contactsContext = contactsContext;

        public async Task<bool> Adicionar(Contato item)
        {
            try
            {
                await _contactsContext.Contatos.AddAsync(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<bool> Atualizar(Contato item)
        {
            try
            {
                _contactsContext.Contatos.Update(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }
          
        }

        public async Task<List<Contato>> Buscar(Guid usuarioId)
        {
            try
            {

                var listaContatos = await _contactsContext.Contatos.Where(c=> c.UsuarioId == usuarioId).ToListAsync();

                return listaContatos;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Contato> BuscarPorId(Guid itemId)
        {
            try
            {

                var contato = await _contactsContext.Contatos.Where(c => c.Id == itemId).Include(e => e.ContatoTelefones).Include(x => x.ContatosEmails).FirstOrDefaultAsync();
               

                return contato ?? null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> Remover(Guid itemId)
        {
            try
            {
                var contato = await _contactsContext.Contatos.FirstOrDefaultAsync(c => c.Id == itemId);

                if (contato == null)
                    return false;

                var retornoRemocao = _contactsContext.Contatos.Remove(contato);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}
