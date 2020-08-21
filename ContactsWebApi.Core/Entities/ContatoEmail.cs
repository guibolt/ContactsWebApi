using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Core.Entities
{
    public class ContatoEmail : BaseEntity
    {
        public string Email { get; set; }
        public Guid ContatoId { get; set; }
        public Contato Contato { get; set; }

    }
}
