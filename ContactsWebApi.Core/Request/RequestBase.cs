using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApi.Core.Request
{
    public abstract class RequestBase
    {
        protected ValidationResult Validation { get; set; }
        public abstract bool EhValido();
        public abstract IList<ValidationFailure> Erros();
    }
}
