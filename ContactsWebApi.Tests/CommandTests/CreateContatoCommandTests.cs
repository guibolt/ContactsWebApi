using AutoFixture;
using ContactsWebApi.Application_.Commands.CreateContato;
using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ContactsWebApi.Tests
{
    public class CreateContatoCommandTests
    {
        private Mock<IGenericRepository<Contato>> _repository = new Mock<IGenericRepository<Contato>>();
        private Mock<ITokenValidationHelper> _validationHelper = new Mock<ITokenValidationHelper>();

        [Fact]
        public async Task Command_Adicionar_Deve_Retornar_Sucesso()
        {
            //Arranje
            var fixture = new Fixture();

            var novoContato = fixture.Create<CreateContatoInputModel>();

            var createContactCommand = new CreateContatoCommand(novoContato, Guid.NewGuid().ToString());

            _repository.Setup(x => x.Adicionar(It.IsAny<Contato>())).Returns(Task.FromResult(true));
            _validationHelper.Setup(x => x.ValidarUsuario(createContactCommand.TokenUsuario)).Returns(true);

            var createContactCommandHandler = new CreateContatoCommandHandler(_repository.Object, _validationHelper.Object);

            //Act

            var handleResult = await createContactCommandHandler.Handle(createContactCommand, new CancellationToken());

            //Act
            Assert.NotNull(handleResult);
            Assert.True(handleResult.Sucesso);
            Assert.Equal("contato registrado com sucesso!",handleResult.Mensagem);
        }

        [Fact]
        public async Task Command_Adicionar_Deve_Retornar_Erro_Ao_Ter_InputModel_Invalido()
        {
            //Arranje
            var novoContato = new CreateContatoInputModel  { };

            var createContactCommand = new CreateContatoCommand(novoContato, Guid.NewGuid().ToString());

            _repository.Setup(x => x.Adicionar(It.IsAny<Contato>())).Returns(Task.FromResult(true));
            _validationHelper.Setup(x => x.ValidarUsuario(createContactCommand.TokenUsuario)).Returns(true);

            var createContactCommandHandler = new CreateContatoCommandHandler(_repository.Object, _validationHelper.Object);

            //Act

            var handleResult = await createContactCommandHandler.Handle(createContactCommand, new CancellationToken());

            //Act
            Assert.NotNull(handleResult);
            Assert.False(handleResult.Sucesso);
        }
        [Fact]
        public async Task Command_Adicionar_Deve_Retornar_Erro_Ao_Ter_Token_Invalido()
        {
            //Arranje
            var fixture = new Fixture();

            var novoContato = fixture.Create<CreateContatoInputModel>();

            var createContactCommand = new CreateContatoCommand(novoContato, "um token inválido");

            _repository.Setup(x => x.Adicionar(It.IsAny<Contato>())).Returns(Task.FromResult(true));
            _validationHelper.Setup(x => x.ValidarUsuario(createContactCommand.TokenUsuario)).Verifiable();

            var createContactCommandHandler = new CreateContatoCommandHandler(_repository.Object, _validationHelper.Object);

            //Act

            var handleResult = await createContactCommandHandler.Handle(createContactCommand, new CancellationToken());

            //Act
            Assert.NotNull(handleResult);
            Assert.False(handleResult.Sucesso);
        }
    } 
}
