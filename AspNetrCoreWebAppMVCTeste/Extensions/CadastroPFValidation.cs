using AspNetrCoreWebAppMVCTeste.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetrCoreWebAppMVCTeste.Extensions
{
    public class CadastroPFValidation : AbstractValidator<Cadastro>
    {
        public CadastroPFValidation()
        {
            RuleFor(x => x.Bairro).NotNull().WithMessage("O Bairro é obrigatório!");
            RuleFor(x => x.Cep).NotNull().WithMessage("O CEP é obrigatório!");
            RuleFor(x => x.Cidade).NotNull().WithMessage("A Cidade é obrigatória!");
            RuleFor(x => x.Logradouro).NotNull().WithMessage("O Logradouro é obrigatório!");
            RuleFor(x => x.Numero).NotNull().WithMessage("O Número é obrigatório!");
            RuleFor(x => x.UF).NotNull().WithMessage("O UF é obrigatório!");

            RuleFor(x => x.CPF).NotNull().WithMessage("O CPF é obrigatório!"); 
            RuleFor(x => x.DataNascimento).Must(Validate_Age).WithMessage("Você deve ter mais de 18 anos.");
            RuleFor(x => x.Nome).NotNull().WithMessage("O Nome é obrigatório!");
            RuleFor(x => x.Sobrenome).NotNull().WithMessage("O Sobrenome é obrigatório!");
        }


        private bool Validate_Age(DateTime Age_)
        {
            DateTime Current = DateTime.Today;
            int age = Current.Year - Convert.ToDateTime(Age_).Year;
            if (Age_.ToString() == "01/01/0001 00:00:00")
                return false;

            if (age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
