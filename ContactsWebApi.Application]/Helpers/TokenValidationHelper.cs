using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Infrastructure.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsWebApi.Application_.Helpers
{
    public class TokenValidationHelper : ITokenValidationHelper
    {
        private readonly ContactsContext _contactsContext;

        public TokenValidationHelper(ContactsContext contactsContext) => _contactsContext = contactsContext;

        public bool ValidarUsuario(string Usertoken)
        {
            var a = Guid.TryParse(Usertoken, out Guid token);
            var b = !_contactsContext.Usuarios.Any(e => e.Id == token);

                return a || b;
        }
            
        
    }
}
