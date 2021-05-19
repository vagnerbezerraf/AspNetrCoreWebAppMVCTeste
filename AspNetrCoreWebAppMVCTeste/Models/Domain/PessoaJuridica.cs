using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AspNetrCoreWebAppMVCTeste.Models.Domain
{
    [Table("PessoaJuridica")]
    public class PessoaJuridica
    {
        [Key]
        public int PessoaJuridicaId { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string CNPJ { get; set; }
        
        [Required(ErrorMessage = "A Razão Social é obrigatória")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [ForeignKey("EnderecoID")]
        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }
}
