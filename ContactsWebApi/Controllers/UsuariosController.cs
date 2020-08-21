using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Application_.Commands.RegisterUsuario;
using ContactsWebApi.Application_.Query.LoginUsuario;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator) => _mediator = mediator;

        [Route("cadastra")]
        [HttpPost]
        public async Task<IActionResult> CadastraUsuario( [FromBody] RegisterUsuarioInputModel inputModel)
        {
            var comando = new RegisterUsuarioCommand(inputModel);

            var retorno = await _mediator.Send(comando);

            return retorno.Sucesso ? Created("", retorno) : (ActionResult)BadRequest(retorno);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LogarUsuario([FromBody] LoginQueryInputModel inputModel)
        {
            var query = new LoginUsuarioQuery(inputModel);

            var retorno = await _mediator.Send(query);

            return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
        }


    }
}
