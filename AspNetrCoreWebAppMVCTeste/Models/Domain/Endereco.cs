using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetrCoreWebAppMVCTeste.Models.Domain
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório")]
        public string UF { get; set; }

    }

}

