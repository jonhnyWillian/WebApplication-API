using Microsoft.EntityFrameworkCore;
using WebApplication_API.DataContext;
using WebApplication_API.Enums;
using WebApplication_API.Models;

namespace WebApplication_API.Service.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa pessoa)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Infomar Dados";
                    serviceResponse.Sucesso = false;
                    
                    return serviceResponse;
                }

                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pessoas.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Pessoa>>> DeletePessoa(int id)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                Pessoa pessoa = _context.Pessoas.FirstOrDefault(x => x.idPessoa == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa nao localizado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Pessoa>> GetPessoaById(int id)
        {
            ServiceResponse<Pessoa> serviceResponse = new ServiceResponse<Pessoa>();

            try
            {
               Pessoa pessoa = _context.Pessoas.FirstOrDefault(x => x.idPessoa == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa nao localizado";
                    serviceResponse.Sucesso = false;
                }
                
                serviceResponse.Dados = pessoa;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Pessoa>>> GetPessoas()
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                serviceResponse.Dados = _context.Pessoas.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum registro encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Pessoa>>> InativaPessoa(int id)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();
            try
            {
                Pessoa pessoa = _context.Pessoas.FirstOrDefault(x => x.idPessoa == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa nao localizado";
                    serviceResponse.Sucesso = false;
                }

                pessoa.Situacao = Situacao.Inativo;
                pessoa.dtUltAlteracao = DateTime.Now.ToLocalTime();

                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pessoas.ToList();
                

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Pessoa>>> UpdatePessoa(Pessoa pessoa)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                Pessoa newPessoa = _context.Pessoas.AsNoTracking().FirstOrDefault(x => x.idPessoa == pessoa.idPessoa);

                if (newPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa nao Encontrada";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                newPessoa.dtUltAlteracao = DateTime.Now.ToLocalTime();
                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoas.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }
    }
}
