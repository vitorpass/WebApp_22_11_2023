﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_22_11_2023.Data;
using WebApp_22_11_2023.Models;

namespace WebApp_22_11_2023.Controllers
{
    public class InventarioController : Controller
    {
        private readonly DBContext _context;

        public InventarioController(DBContext context)
        {
            _context = context;
        }

        // GET: Inventario
        public async Task<IActionResult> Index()
        {
              return _context.Inventario != null ? 
                          View(await _context.Inventario.ToListAsync()) :
                          Problem("Entity set 'DBContext.Inventario'  is null.");
        }

        // GET: Inventario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .FirstOrDefaultAsync(m => m.id_inventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventario/Create
        public IActionResult Create()
        {
            InventarioModel model = new();
            model.clientes = _context.CadClientes.ToList();
            model.maquinas = _context.CadMaquinas.ToList();
            return View(model);
        }

        // POST: Inventario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_inventario,id_cliente,id_maquina,quantidade,data_aquisicao,preco_unitario,observacoes")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: Inventario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return View(inventario);
        }

        // POST: Inventario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_inventario,id_cliente,id_maquina,quantidade,data_aquisicao,preco_unitario,observacoes")] Inventario inventario)
        {
            if (id != inventario.id_inventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.id_inventario))
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
            return View(inventario);
        }

        // GET: Inventario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .FirstOrDefaultAsync(m => m.id_inventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventario == null)
            {
                return Problem("Entity set 'DBContext.Inventario'  is null.");
            }
            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario != null)
            {
                _context.Inventario.Remove(inventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
          return (_context.Inventario?.Any(e => e.id_inventario == id)).GetValueOrDefault();
        }
    }
}
