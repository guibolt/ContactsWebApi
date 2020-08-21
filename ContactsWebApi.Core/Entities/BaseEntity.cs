using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactsWebApi.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
    }
}
