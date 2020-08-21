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
    public class TelefoneRepository : IGenericRepository<ContatoTelefone>
    {
        private readonly ContactsContext _contactsContext;

        public TelefoneRepository(ContactsContext contactsContext) => _contactsContext = contactsContext;

        public async Task<bool> Adicionar(ContatoTelefone item)
        {
            try
            {
                await _contactsContext.ContatoTelefones.AddAsync(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<bool> Atualizar(ContatoTelefone item)
        {
            try
            {
                _contactsContext.ContatoTelefones.Update(item);

                var retornoAtualizacao = await _contactsContext.SaveChangesAsync();

                return retornoAtualizacao == 1;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<List<ContatoTelefone>> Buscar(Guid usuarioId)
        {
            try
            {

                var listaContatoTelefones = await _contactsContext.ContatoTelefones.Where(c => c.ContatoId == usuarioId).ToListAsync();

                return listaContatoTelefones;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ContatoTelefone> BuscarPorId(Guid itemId)
        {
            try
            {

                var contatoTelefone = await _contactsContext.ContatoTelefones.FirstOrDefaultAsync(c => c.Id == itemId);

                return contatoTelefone ?? null;
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
                var contatoTelefone = await _contactsContext.ContatoTelefones.FirstOrDefaultAsync(c => c.Id == itemId);

                if (contatoTelefone == null)
                    return false;

                var retornoRemocao = _contactsContext.ContatoTelefones.Remove(contatoTelefone);

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
