using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Application_.Helpers.Interfaces
{
    public interface ITokenValidationHelper
    {
        public bool ValidarUsuario(string Usertoken);
    }
}
