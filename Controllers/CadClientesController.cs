﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_22_11_2023.Data;
using WebApp_22_11_2023.Models;

namespace WebApp_22_11_2023.Controllers
{
    public class CadClientesController : Controller
    {
        private readonly DBContext _context;

        public CadClientesController(DBContext context)
        {
            _context = context;
        }

        // GET: CadClientes
        public async Task<IActionResult> Index()
        {
              return _context.CadClientes != null ? 
                          View(await _context.CadClientes.ToListAsync()) :
                          Problem("Entity set 'DBContext.CadClientes'  is null.");
        }

        // GET: CadClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadClientes == null)
            {
                return NotFound();
            }

            var cadClientes = await _context.CadClientes
                .FirstOrDefaultAsync(m => m.id_cliente == id);
            if (cadClientes == null)
            {
                return NotFound();
            }

            return View(cadClientes);
        }

        // GET: CadClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_cliente,nome,email,telefone")] CadClientes cadClientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadClientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadClientes);
        }

        // GET: CadClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadClientes == null)
            {
                return NotFound();
            }

            var cadClientes = await _context.CadClientes.FindAsync(id);
            if (cadClientes == null)
            {
                return NotFound();
            }
            return View(cadClientes);
        }

        // POST: CadClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_cliente,nome,email,telefone")] CadClientes cadClientes)
        {
            if (id != cadClientes.id_cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadClientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadClientesExists(cadClientes.id_cliente))
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
            return View(cadClientes);
        }

        // GET: CadClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadClientes == null)
            {
                return NotFound();
            }

            var cadClientes = await _context.CadClientes
                .FirstOrDefaultAsync(m => m.id_cliente == id);
            if (cadClientes == null)
            {
                return NotFound();
            }

            return View(cadClientes);
        }

        // POST: CadClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadClientes == null)
            {
                return Problem("Entity set 'DBContext.CadClientes'  is null.");
            }
            var cadClientes = await _context.CadClientes.FindAsync(id);
            if (cadClientes != null)
            {
                _context.CadClientes.Remove(cadClientes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadClientesExists(int id)
        {
          return (_context.CadClientes?.Any(e => e.id_cliente == id)).GetValueOrDefault();
        }
    }
}
