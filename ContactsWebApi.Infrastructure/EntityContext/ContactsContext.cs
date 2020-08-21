using ContactsWebApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ContactsWebApi.Infrastructure.EntityContext
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<ContatoTelefone> ContatoTelefones { get; set; }
        public DbSet<ContatoEmail> ContatoEmails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Contato>()
                .HasOne<Usuario>(c => c.Usuario)
                .WithMany(g => g.Contatos)
                .HasForeignKey(s => s.UsuarioId);

            modelBuilder
                .Entity<ContatoEmail>()
                .HasOne<Contato>(c => c.Contato)
                .WithMany(g => g.ContatosEmails)
                .HasForeignKey(s => s.ContatoId);

            modelBuilder
                .Entity<ContatoTelefone>()
                .HasOne<Contato>(c => c.Contato)
                .WithMany(g => g.ContatoTelefones)
                .HasForeignKey(s => s.ContatoId);


        }
    }
}
