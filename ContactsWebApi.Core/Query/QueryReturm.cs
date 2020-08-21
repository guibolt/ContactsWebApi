using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Core.Query
{
    public class QueryReturn
    {
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Erros { get; private set; }
        public dynamic ObjetoRetorno { get; private set; }

        public QueryReturn(bool sucesso) => Sucesso = sucesso;

        public QueryReturn(bool sucesso, string mensagem) : this(sucesso) => Mensagem = mensagem;

        public QueryReturn(bool sucesso, object erros, string mensagem) : this(sucesso)
        {
            Erros = erros;
            Mensagem = mensagem;
        }

        public QueryReturn(bool sucesso, string mensagem, dynamic objetoRetorno) : this(sucesso, mensagem) => ObjetoRetorno = objetoRetorno;
    }
}
