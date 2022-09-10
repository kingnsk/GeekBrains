using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Block5_8.Data;
using Block5_8.Models;

namespace Block5_8.Controllers
{
    public class AdminController : Controller
    {
        private readonly Block5_8Context _context;

        public AdminController(Block5_8Context context)
        {
            _context = context;
        }

        // GET: OfficeWorks
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfficeWork.ToListAsync());
        }

        // GET: OfficeWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeWork = await _context.OfficeWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeWork == null)
            {
                return NotFound();
            }

            return View(officeWork);
        }

        // GET: OfficeWorks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficeWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Departament,Position,Name,BeginningOfWork,EndOfWork")] OfficeWork officeWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officeWork);
        }

        // GET: OfficeWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeWork = await _context.OfficeWork.FindAsync(id);
            if (officeWork == null)
            {
                return NotFound();
            }
            return View(officeWork);
        }

        // POST: OfficeWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Departament,Position,Name,BeginningOfWork,EndOfWork")] OfficeWork officeWork)
        {
            if (id != officeWork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeWorkExists(officeWork.Id))
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
            return View(officeWork);
        }

        // GET: OfficeWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeWork = await _context.OfficeWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeWork == null)
            {
                return NotFound();
            }

            return View(officeWork);
        }

        // POST: OfficeWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeWork = await _context.OfficeWork.FindAsync(id);
            _context.OfficeWork.Remove(officeWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeWorkExists(int id)
        {
            return _context.OfficeWork.Any(e => e.Id == id);
        }
    }
}
