using System.ComponentModel.DataAnnotations;
using WebApplication_API.Enums;

namespace WebApplication_API.Models
{
    public class Pessoa
    {
        [Key]
        public int idPessoa { get; set; }
        public string nmPessoa { get; set; }
        public DateTime dtNasc { get; set; }        
        public string nrCpf  { get; set; }
        public Situacao Situacao { get; set; }
        public Telefone Telefone { get; set; }
        public DateTime dtCadastro { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime dtUltAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
