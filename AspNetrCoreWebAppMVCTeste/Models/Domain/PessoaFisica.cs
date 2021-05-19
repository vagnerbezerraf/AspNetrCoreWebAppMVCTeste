using AspNetrCoreWebAppMVCTeste.Extensions;
using AspNetrCoreWebAppMVCTeste.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AspNetrCoreWebAppMVCTeste.Models.Domain
{
    [Table("PessoaFisica")]
    public class PessoaFisica
    {
        [Key]
        public int PessoaFisicaId { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [ForeignKey("EnderecoID")]
        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }
}
