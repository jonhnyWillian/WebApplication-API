using WebApplication_API.Models;

namespace WebApplication_API.Service.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<Pessoa>>> GetPessoas();
        Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa pessoa);
        Task<ServiceResponse<Pessoa>> GetPessoaById(int id);
        Task<ServiceResponse<List<Pessoa>>> UpdatePessoa(Pessoa pessoa);
        Task<ServiceResponse<List<Pessoa>>> DeletePessoa(int id);
        Task<ServiceResponse<List<Pessoa>>> InativaPessoa(int id);
    }
}
