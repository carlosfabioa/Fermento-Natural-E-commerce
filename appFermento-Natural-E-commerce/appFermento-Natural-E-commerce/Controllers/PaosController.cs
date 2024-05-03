using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appFermento_Natural_E_commerce.Data;
using appFermento_Natural_E_commerce.Models;
using Microsoft.Data.SqlClient;

namespace appFermento_Natural_E_commerce.Controllers
{
    public class PaosController : Controller
    {
        private readonly appFermento_Natural_E_commerceContext _context;

        public PaosController(appFermento_Natural_E_commerceContext context)
        {
            _context = context;
        }

        // GET: Paos
        public async Task<IActionResult> Index()
        {
              return _context.Pao != null ? 
                          View(await _context.Pao.ToListAsync()) :
                          Problem("Entity set 'appFermento_Natural_E_commerceContext.Pao'  is null.");
        }

        // GET: Paos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pao == null)
            {
                return NotFound();
            }

            var pao = await _context.Pao
                .FirstOrDefaultAsync(m => m.id == id);
            if (pao == null)
            {
                return NotFound();
            }

            return View(pao);
        }

        // GET: Paos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tipo,tipoFermentacao,fornada,preco")] Pao pao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pao);
        }

        // GET: Paos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pao == null)
            {
                return NotFound();
            }

            var pao = await _context.Pao.FindAsync(id);
            if (pao == null)
            {
                return NotFound();
            }
            return View(pao);
        }

        // POST: Paos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tipo,tipoFermentacao,fornada,preco")] Pao pao)
        {
            if (id != pao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaoExists(pao.id))
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
            return View(pao);
        }

        // GET: Paos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pao == null)
            {
                return NotFound();
            }

            var pao = await _context.Pao
                .FirstOrDefaultAsync(m => m.id == id);
            if (pao == null)
            {
                return NotFound();
            }

            return View(pao);
        }

        // POST: Paos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pao == null)
            {
                return Problem("Entity set 'appFermento_Natural_E_commerceContext.Pao'  is null.");
            }
            var pao = await _context.Pao.FindAsync(id);
            if (pao != null)
            {
                _context.Pao.Remove(pao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaoExists(int id)
        {
          return (_context.Pao?.Any(e => e.id == id)).GetValueOrDefault();
        }

        // GET: Produtos
        public async Task<IActionResult> ListarPao()
        {
            return View(await _context.Pao.ToListAsync());
        }


    }
}
