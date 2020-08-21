using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Core.Entities
{
    public class ContatoTelefone : BaseEntity
    {
        public string TeleFone { get; set; }
        public Guid ContatoId { get; set; }
        public Contato Contato { get; set; }
    }
}
