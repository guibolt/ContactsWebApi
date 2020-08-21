using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IList<Contato> Contatos { get; private set; }
    }
}
