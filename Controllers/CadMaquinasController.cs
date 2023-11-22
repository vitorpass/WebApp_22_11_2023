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
    public class CadMaquinasController : Controller
    {
        private readonly DBContext _context;

        public CadMaquinasController(DBContext context)
        {
            _context = context;
        }

        // GET: CadMaquinas
        public async Task<IActionResult> Index()
        {
              return _context.CadMaquinas != null ? 
                          View(await _context.CadMaquinas.ToListAsync()) :
                          Problem("Entity set 'DBContext.CadMaquinas'  is null.");
        }

        // GET: CadMaquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadMaquinas == null)
            {
                return NotFound();
            }

            var cadMaquinas = await _context.CadMaquinas
                .FirstOrDefaultAsync(m => m.id_maquina == id);
            if (cadMaquinas == null)
            {
                return NotFound();
            }

            return View(cadMaquinas);
        }

        // GET: CadMaquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_maquina,nome_maquina,tipo_maquina,status_maquina")] CadMaquinas cadMaquinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadMaquinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadMaquinas);
        }

        // GET: CadMaquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadMaquinas == null)
            {
                return NotFound();
            }

            var cadMaquinas = await _context.CadMaquinas.FindAsync(id);
            if (cadMaquinas == null)
            {
                return NotFound();
            }
            return View(cadMaquinas);
        }

        // POST: CadMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_maquina,nome_maquina,tipo_maquina,status_maquina")] CadMaquinas cadMaquinas)
        {
            if (id != cadMaquinas.id_maquina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadMaquinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadMaquinasExists(cadMaquinas.id_maquina))
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
            return View(cadMaquinas);
        }

        // GET: CadMaquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadMaquinas == null)
            {
                return NotFound();
            }

            var cadMaquinas = await _context.CadMaquinas
                .FirstOrDefaultAsync(m => m.id_maquina == id);
            if (cadMaquinas == null)
            {
                return NotFound();
            }

            return View(cadMaquinas);
        }

        // POST: CadMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadMaquinas == null)
            {
                return Problem("Entity set 'DBContext.CadMaquinas'  is null.");
            }
            var cadMaquinas = await _context.CadMaquinas.FindAsync(id);
            if (cadMaquinas != null)
            {
                _context.CadMaquinas.Remove(cadMaquinas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadMaquinasExists(int id)
        {
          return (_context.CadMaquinas?.Any(e => e.id_maquina == id)).GetValueOrDefault();
        }
    }
}
