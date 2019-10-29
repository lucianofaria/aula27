using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // validações

namespace Projeto.Services.Models
{
    public class DependenteCadastroModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public int IdFuncionario { get; set; }
    }
}