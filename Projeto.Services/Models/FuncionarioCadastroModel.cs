using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // validacoes

namespace Projeto.Services.Models
{
    public class FuncionarioCadastroModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Salario { get; set; }
        [Required]
        public DateTime DataAdmissao { get; set; }
    }
}