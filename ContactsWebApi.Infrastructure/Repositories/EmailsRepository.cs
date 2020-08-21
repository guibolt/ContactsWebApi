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
    public class EmailsRepository : IGenericRepository<ContatoEmail>
    {
        private readonly ContactsContext _contactsContext;

        public EmailsRepository(ContactsContext contactsContext) => _contactsContext = contactsContext;

        public async Task<bool> Adicionar(ContatoEmail item)
        {
            try
            {
                await _contactsContext.ContatoEmails.AddAsync(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<bool> Atualizar(ContatoEmail item)
        {
            try
            {
                _contactsContext.ContatoEmails.Update(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<List<ContatoEmail>> Buscar(Guid usuarioId)
        {
            try
            {

                var listaContatoEmails = await _contactsContext.ContatoEmails.Where(c => c.ContatoId == usuarioId).ToListAsync();

                return listaContatoEmails;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ContatoEmail> BuscarPorId(Guid itemId)
        {
            try
            {

                var contatoEmail = await _contactsContext.ContatoEmails.FirstOrDefaultAsync(c => c.Id == itemId);

                return contatoEmail ?? null;
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
                var contatoEmail = await _contactsContext.ContatoEmails.FirstOrDefaultAsync(c => c.Id == itemId);

                if (contatoEmail == null)
                    return false;

                var retornoRemocao = _contactsContext.ContatoEmails.Remove(contatoEmail);

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
