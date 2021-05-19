using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetrCoreWebAppMVCTeste.Data;
using AspNetrCoreWebAppMVCTeste.Models.Domain;

namespace AspNetrCoreWebAppMVCTeste.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoaJuridicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PessoaJuridica
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PessoaJuridica.Include(p => p.Endereco);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PessoaJuridica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridica
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(m => m.PessoaJuridicaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // GET: PessoaJuridica/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "EnderecoId", "Bairro");
            return View();
        }

        // POST: PessoaJuridica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaJuridicaId,CNPJ,RazaoSocial,NomeFantasia,EnderecoId")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "EnderecoId", "Bairro", pessoaJuridica.EnderecoId);
            return View(pessoaJuridica);
        }

        // GET: PessoaJuridica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "EnderecoId", "Bairro", pessoaJuridica.EnderecoId);
            return View(pessoaJuridica);
        }

        // POST: PessoaJuridica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaJuridicaId,CNPJ,RazaoSocial,NomeFantasia,EnderecoId")] PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.PessoaJuridicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaJuridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaJuridicaExists(pessoaJuridica.PessoaJuridicaId))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "EnderecoId", "Bairro", pessoaJuridica.EnderecoId);
            return View(pessoaJuridica);
        }

        // GET: PessoaJuridica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridica
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(m => m.PessoaJuridicaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // POST: PessoaJuridica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);
            _context.PessoaJuridica.Remove(pessoaJuridica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaJuridicaExists(int id)
        {
            return _context.PessoaJuridica.Any(e => e.PessoaJuridicaId == id);
        }
    }
}
