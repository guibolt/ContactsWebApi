using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ContactsWebApi.Application_.Commands.CreateContato;
using ContactsWebApi.Application_.Commands.CreateContatoEmail;
using ContactsWebApi.Application_.Commands.CreateContatoTelefone;
using ContactsWebApi.Application_.Query.BuscaContatos;
using ContactsWebApi.Application_.Query.BuscarContato;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContatosController(IMediator mediator) => _mediator = mediator;


        [Route("cadastra")]
        [HttpPost]
        public async Task<IActionResult> CadastraContato([FromQuery] string TokenUsuario,[FromBody] CreateContatoInputModel inputModel)
        {
            var comando = new CreateContatoCommand(inputModel,TokenUsuario);
            var retorno = await _mediator.Send(comando);

            return retorno.Sucesso ? Created("", retorno) : (ActionResult)BadRequest(retorno);
        }

        [HttpGet("busca")]
        public async Task<IActionResult> BuscaContatos([FromQuery] string TokenUsuario)
        {

            var query = new BuscarContatosQuery(TokenUsuario);
            var retorno = await _mediator.Send(query);

            return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
        }

        [Route("cadastra/email")]
        [HttpPost]
        public async Task<IActionResult> CadastraContatoEmails([FromQuery] string TokenUsuario, [FromBody] CreateContatoEmailInputModel inputModel)
        {
            var comando = new CreateContatoEmailCommand(TokenUsuario,inputModel);
            var retorno = await _mediator.Send(comando);

            return retorno.Sucesso ? Created("", retorno) : (ActionResult)BadRequest(retorno);
        }
      
        [Route("cadastra/telefone")]
        [HttpPost]
        public async Task<IActionResult> CadastraContatosTelefones([FromQuery] string TokenUsuario, [FromBody] CreateContatoTelefoneInputModel inputModel)
        {
            var comando = new CreateContatoTelefoneCommand(inputModel, TokenUsuario);
            var retorno = await _mediator.Send(comando);

            return retorno.Sucesso ? Created("", retorno) : (ActionResult)BadRequest(retorno);
        }

        [Route("busca/contato")]
        [HttpGet]
        public async Task<IActionResult> CadastraContatosTelefones([FromQuery] string TokenUsuario, [FromQuery] string contatoId)
        {
            var query = new BuscarContatoQuery(TokenUsuario, contatoId);
            var retorno = await _mediator.Send(query);

            return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno); ;
        }

        [Route("busca/{cep}")]
        [HttpGet]
        public async Task<IActionResult> BuscaCep(string cep)
        {
            var response = await
            new HttpClient().GetAsync($"https://viacep.com.br/ws/{cep}/json/");


          return  Ok(await response.Content.ReadAsStringAsync());
        }
            
            
     
    }
}
