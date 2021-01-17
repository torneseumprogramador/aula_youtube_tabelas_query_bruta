using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aula_youtube_tabelas_query_bruta.Models.Dominio.Entidades;
using aula_youtube_tabelas_query_bruta.Models.Infraestrutura.Database;

namespace aula_youtube_tabelas_query_bruta.Controllers
{
    public class PedidoProdutosController : Controller
    {
        private readonly ContextoLoja1 _context;

        public PedidoProdutosController(ContextoLoja1 context)
        {
            _context = context;
        }

        // GET: PedidoProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PedidoProdutos.ToListAsync());
        }

        // GET: PedidoProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidoProdutos
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return View(pedidoProduto);
        }

        // GET: PedidoProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPedido,IdProduto,Valor,Quantidade")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoProduto);
        }

        // GET: PedidoProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidoProdutos.FindAsync(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }
            return View(pedidoProduto);
        }

        // POST: PedidoProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPedido,IdProduto,Valor,Quantidade")] PedidoProduto pedidoProduto)
        {
            if (id != pedidoProduto.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoProdutoExists(pedidoProduto.IdPedido))
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
            return View(pedidoProduto);
        }

        // GET: PedidoProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidoProdutos
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return View(pedidoProduto);
        }

        // POST: PedidoProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoProduto = await _context.PedidoProdutos.FindAsync(id);
            _context.PedidoProdutos.Remove(pedidoProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoProdutoExists(int id)
        {
            return _context.PedidoProdutos.Any(e => e.IdPedido == id);
        }
    }
}
