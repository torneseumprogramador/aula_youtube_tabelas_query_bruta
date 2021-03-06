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
    public class PedidosController : Controller
    {
        private readonly ContextoLoja1 _context;

        public PedidosController(ContextoLoja1 context)
        {
            _context = context;
        }

        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Pedidos.ToListAsync());
        // }

        // public IActionResult Index()
        // {
        //     return View(_context.Pedidos.FromSqlRaw("SELECT \"Id\", \"IdCliente\", \"Valor\", \"Data\" FROM \"Pedidos\"").Include(p => p.Cliente).ToList());
        // }

        // public async Task<IActionResult> Index()
        // {
        //     var lista = await _context.Pedidos.Include(p => p.Cliente).ToListAsync();
        //     return View(lista);
        // }

        // public async Task<IActionResult> Index()
        // {
        //     var lista = await _context.Clientes.Join(
        //     _context.Pedidos,
        //         cliente => cliente.Id,
        //         pedido => pedido.ClienteId,
        //         (cliente, pedido) => new Models.Dominio.Views.Pedido
        //         {
        //             Id = pedido.Id,
        //             Cliente = cliente.Nome,
        //             Data = pedido.Data,
        //             Valor = pedido.Valor
        //         }
        //     ).ToListAsync();

        //     return View(lista);
        // }

        public IActionResult Index()
        {
            var lista = new List<Models.Dominio.Views.Pedido>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT \"Pedidos\".\"Id\", \"Clientes\".\"Nome\" as \"Cliente\", \"Pedidos\".\"Valor\", \"Pedidos\".\"Data\" FROM \"Pedidos\" inner join \"Clientes\" on \"Clientes\".\"Id\" = \"Pedidos\".\"IdCliente\"";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        lista.Add(new Models.Dominio.Views.Pedido{
                            Id = Convert.ToInt32(result["Id"]),
                            Cliente = result["Cliente"].ToString(),
                            Valor = Convert.ToDouble(result["Valor"]),
                            Data = Convert.ToDateTime(result["Data"]),
                        });
                    }
                }
            }

            return View(lista);
        }

        // public IActionResult Index()
        // {
        //     var lista = _context.Clientes.Join(
        //     _context.Pedidos,
        //         cliente => cliente.Id,
        //         pedido => pedido.IdCliente,
        //         (cliente, pedido) => new aula_youtube_tabelas_query_bruta.Models.Dominio.Views.Pedido
        //         {
        //             Id = pedido.Id,
        //             Cliente = cliente.Nome,
        //             Data = pedido.Data,
        //             Valor = pedido.Valor
        //         }
        //     ).ToList();

        //     return View(lista);
        // }

        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Pedidos.ToListAsync());
        // }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,Valor,Data")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,Valor,Data")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
