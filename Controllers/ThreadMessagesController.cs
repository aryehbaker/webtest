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
    public class ThreadMessagesController : Controller
    {
        private readonly Ticketsystem1Context _context;

        public ThreadMessagesController(Ticketsystem1Context context)
        {
            _context = context;
        }

        // GET: ThreadMessages
        public async Task<IActionResult> Index()
        {
            var ticketsystem1Context = _context.ThreadMessages.Include(t => t.MessageStatusNavigation).Include(t => t.Thread).Include(t => t.User);
            return View(await ticketsystem1Context.ToListAsync());
        }

        // GET: ThreadMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThreadMessages == null)
            {
                return NotFound();
            }

            var threadMessage = await _context.ThreadMessages
                .Include(t => t.MessageStatusNavigation)
                .Include(t => t.Thread)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threadMessage == null)
            {
                return NotFound();
            }

            return View(threadMessage);
        }

        // GET: ThreadMessages/Create
        public IActionResult Create()
        {
            ViewData["MessageStatus"] = new SelectList(_context.MessageStatuses, "Id", "Id");
            ViewData["ThreadId"] = new SelectList(_context.Threads, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ThreadMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ThreadId,Incoming,UserId,MessageStatus,DateOfCreation,SoftDeleted,SoftDeleteReason,SoftDeleteDate")] ThreadMessage threadMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threadMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MessageStatus"] = new SelectList(_context.MessageStatuses, "Id", "Id", threadMessage.MessageStatus);
            ViewData["ThreadId"] = new SelectList(_context.Threads, "Id", "Id", threadMessage.ThreadId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", threadMessage.UserId);
            return View(threadMessage);
        }

        // GET: ThreadMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThreadMessages == null)
            {
                return NotFound();
            }

            var threadMessage = await _context.ThreadMessages.FindAsync(id);
            if (threadMessage == null)
            {
                return NotFound();
            }
            ViewData["MessageStatus"] = new SelectList(_context.MessageStatuses, "Id", "Id", threadMessage.MessageStatus);
            ViewData["ThreadId"] = new SelectList(_context.Threads, "Id", "Id", threadMessage.ThreadId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", threadMessage.UserId);
            return View(threadMessage);
        }

        // POST: ThreadMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ThreadId,Incoming,UserId,MessageStatus,DateOfCreation,SoftDeleted,SoftDeleteReason,SoftDeleteDate")] ThreadMessage threadMessage)
        {
            if (id != threadMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threadMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreadMessageExists(threadMessage.Id))
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
            ViewData["MessageStatus"] = new SelectList(_context.MessageStatuses, "Id", "Id", threadMessage.MessageStatus);
            ViewData["ThreadId"] = new SelectList(_context.Threads, "Id", "Id", threadMessage.ThreadId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", threadMessage.UserId);
            return View(threadMessage);
        }

        // GET: ThreadMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThreadMessages == null)
            {
                return NotFound();
            }

            var threadMessage = await _context.ThreadMessages
                .Include(t => t.MessageStatusNavigation)
                .Include(t => t.Thread)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threadMessage == null)
            {
                return NotFound();
            }

            return View(threadMessage);
        }

        // POST: ThreadMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThreadMessages == null)
            {
                return Problem("Entity set 'Ticketsystem1Context.ThreadMessages'  is null.");
            }
            var threadMessage = await _context.ThreadMessages.FindAsync(id);
            if (threadMessage != null)
            {
                _context.ThreadMessages.Remove(threadMessage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreadMessageExists(int id)
        {
          return (_context.ThreadMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
