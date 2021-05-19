using AspNetrCoreWebAppMVCTeste.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetrCoreWebAppMVCTeste.Extensions
{
    public class CadastroPJValidation : AbstractValidator<Cadastro>
    {
        public CadastroPJValidation()
        {
            RuleFor(x => x.Bairro).NotNull().WithMessage("O Bairro é obrigatório!");
            RuleFor(x => x.Cep).NotNull().WithMessage("O CEP é obrigatório!");
            RuleFor(x => x.Cidade).NotNull().WithMessage("A Cidade é obrigatória!");
            RuleFor(x => x.Logradouro).NotNull().WithMessage("O Logradouro é obrigatório!");
            RuleFor(x => x.Numero).NotNull().WithMessage("O Número é obrigatório!");
            RuleFor(x => x.UF).NotNull().WithMessage("O UF é obrigatório!");

            RuleFor(x => x.CNPJ).NotNull().WithMessage("O CNPJ é obrigatório!");
            RuleFor(x => x.NomeFantasia).NotNull().WithMessage("O Nome Fantasia é obrigatório!");
            RuleFor(x => x.RazaoSocial).NotNull().WithMessage("A Razão Social é obrigatória!");

        }
    }
}
