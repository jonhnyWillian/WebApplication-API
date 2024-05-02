using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_API.Models;
using WebApplication_API.Service.PessoaService;

namespace WebApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;

        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> GetPessoas()
        {
            return Ok(await _pessoaInterface.GetPessoas());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> CreatePessoa(Pessoa pessoa)
        {
            return Ok(await _pessoaInterface.CreatePessoa(pessoa));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> UpdatePessoa(Pessoa pessoa)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = await _pessoaInterface.UpdatePessoa(pessoa);
            
            return Ok(serviceResponse);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Pessoa>>> GetPessoaById(int id)
        {
            ServiceResponse<Pessoa> serviceResponse = await _pessoaInterface.GetPessoaById(id);

            return Ok(serviceResponse);
        }

        [HttpPut("InativaPessoa")]
        public async Task<ActionResult<ServiceResponse<Pessoa>>> InativaPessoa(int id)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = await _pessoaInterface.InativaPessoa(id);

            return Ok(serviceResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Pessoa>>> DeletePessoa(int id)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = await _pessoaInterface.DeletePessoa(id);
            return Ok(serviceResponse);
        }

    }
}

