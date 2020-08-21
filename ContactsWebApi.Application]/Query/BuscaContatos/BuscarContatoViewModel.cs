using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Query.BuscaContatos
{
    public class BuscarContatoViewModel
    {
        public Guid IdContato { get; set; }
        public string Nome { get; set; }
        public string Nota { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
