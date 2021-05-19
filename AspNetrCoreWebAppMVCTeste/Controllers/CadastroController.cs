using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetrCoreWebAppMVCTeste.Data;
using AspNetrCoreWebAppMVCTeste.Models;
using AspNetrCoreWebAppMVCTeste.Models.Domain;
using AspNetrCoreWebAppMVCTeste.Extensions;

namespace AspNetrCoreWebAppMVCTeste.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaFisica.ToListAsync());
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.CadastroId == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {
            ViewBag.Tipo = "PF";
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastroId,CPF,DataNascimento,Nome,Sobrenome,CNPJ,RazaoSocial,NomeFantasia,Cep,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] Cadastro cadastro)
        {
            var validadorPf = new CadastroPFValidation().Validate(cadastro);
            var validadorPj = new CadastroPJValidation().Validate(cadastro);

            if (validadorPf.IsValid)
            {
                var pessoaFisica = new PessoaFisica()
                {
                    CPF = cadastro.CPF,
                    DataNascimento = cadastro.DataNascimento,
                    Nome = cadastro.Nome,
                    Sobrenome = cadastro.Sobrenome,
                    Endereco = new Endereco()
                    {
                        Bairro = cadastro.Bairro,
                        Cep = cadastro.Cep,
                        Cidade = cadastro.Cidade,
                        Complemento = cadastro.Complemento,
                        Logradouro = cadastro.Logradouro,
                        Numero = cadastro.Numero,
                        UF = cadastro.UF
                    }
                };

                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PessoaFisica");
            }

            if (validadorPj.IsValid)
            {
                var pessoaJuridica = new PessoaJuridica()
                {
                    CNPJ = cadastro.CNPJ,
                    NomeFantasia = cadastro.NomeFantasia,
                    RazaoSocial = cadastro.RazaoSocial,
                    Endereco = new Endereco()
                    {
                        Bairro = cadastro.Bairro,
                        Cep = cadastro.Cep,
                        Cidade = cadastro.Cidade,
                        Complemento = cadastro.Complemento,
                        Logradouro = cadastro.Logradouro,
                        Numero = cadastro.Numero,
                        UF = cadastro.UF
                    }
                };

                _context.Add(pessoaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PessoaJuridica");
            }

            foreach (var result in validadorPj.Errors.Concat(validadorPf.Errors))
            {
                ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
            }

            return View(cadastro);
        }


        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadastroId,CPF,DataNascimento,Nome,Sobrenome,CNPJ,RazaoSocial,NomeFantasia,Cep,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] Cadastro cadastro)
        {
            if (id != cadastro.CadastroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.CadastroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.CadastroId == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);
            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
            return _context.Cadastro.Any(e => e.CadastroId == id);
        }
    }
}
