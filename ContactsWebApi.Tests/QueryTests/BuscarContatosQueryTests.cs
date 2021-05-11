using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Application_.Query.BuscaContatos;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ContactsWebApi.Tests.QueryTests
{
    public class BuscarContatosQueryTests
    {
        private Mock<IGenericRepository<Contato>> _repository = new Mock<IGenericRepository<Contato>>();
        private Mock<ITokenValidationHelper> _validationHelper = new Mock<ITokenValidationHelper>();

        [Fact]
        public async Task Deve_Retornar_Sucesso_E_Lista_Contatos()
        {
            //Arranje
            var tokenUsuario = Guid.NewGuid().ToString();

            var buscaContatosQuery = new BuscarContatosQuery(tokenUsuario);

            _validationHelper.Setup(x => x.ValidarUsuario(tokenUsuario)).Returns(true);

            var queryHandler = new BuscarContatosQueryHandler(_repository.Object, _validationHelper.Object);
            
            //Act

            var queryResult = await queryHandler.Handle(buscaContatosQuery, new CancellationToken());

            var b = 'z';
            //Assert

            Assert.NotNull(queryResult);
        }

    }
}
