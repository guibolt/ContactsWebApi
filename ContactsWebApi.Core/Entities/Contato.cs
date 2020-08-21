using System;
using System.Collections.Generic;


namespace ContactsWebApi.Core.Entities
{
    public class Contato : BaseEntity
    {
        public string Nome { get; set; }
        public string Nota { get; set; }
        public IList<ContatoEmail> ContatosEmails { get;  set; }
        public IList<ContatoTelefone> ContatoTelefones { get;  set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
