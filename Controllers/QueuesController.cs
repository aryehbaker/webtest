using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webtest.Models;

namespace webtest.Controllers
{
    public class QueuesController : Controller
    {
        private readonly Ticketsystem1Context _context;

        public QueuesController(Ticketsystem1Context context)
        {
            _context = context;
        }

        // GET: Queues
        public async Task<IActionResult> Index()
        {
              return _context.Queues != null ? 
                          View(await _context.Queues.ToListAsync()) :
                          Problem("Entity set 'Ticketsystem1Context.Queues'  is null.");
        }

        // GET: Queues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Queues == null)
            {
                return NotFound();
            }

            var queue = await _context.Queues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queue == null)
            {
                return NotFound();
            }

            return View(queue);
        }

        // GET: Queues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Queues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QueueName")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(queue);
        }

        // GET: Queues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Queues == null)
            {
                return NotFound();
            }

            var queue = await _context.Queues.FindAsync(id);
            if (queue == null)
            {
                return NotFound();
            }
            return View(queue);
        }

        // POST: Queues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QueueName")] Queue queue)
        {
            if (id != queue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueueExists(queue.Id))
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
            return View(queue);
        }

        // GET: Queues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Queues == null)
            {
                return NotFound();
            }

            var queue = await _context.Queues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queue == null)
            {
                return NotFound();
            }

            return View(queue);
        }

        // POST: Queues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Queues == null)
            {
                return Problem("Entity set 'Ticketsystem1Context.Queues'  is null.");
            }
            var queue = await _context.Queues.FindAsync(id);
            if (queue != null)
            {
                _context.Queues.Remove(queue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QueueExists(int id)
        {
          return (_context.Queues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
