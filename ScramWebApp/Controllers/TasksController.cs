using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScramWebApp.Data;
using ScramWebApp.Models;

namespace ScramWebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ScrumContext _context;

        public TasksController(ScrumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            TaskVM taskVM = new TaskVM
            {
                Backlogs = await _context.Backlogs.ToListAsync(),
                Tasks = await _context.Tasks.ToListAsync(),

            };
            return View(taskVM);
        }

        public IActionResult Create()
        {
            ViewData["BacklogId"] = new SelectList(_context.Backlogs, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BacklogId"] = new SelectList(_context.Backlogs, "Id", "Name", taskModel.BacklogId);
            return View(taskModel);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }
            ViewData["BacklogId"] = new SelectList(_context.Backlogs, "Id", "Name", taskModel.BacklogId);
            return View(taskModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskModelExists(taskModel.Id))
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
            ViewData["BacklogId"] = new SelectList(_context.Backlogs, "Id", "Name", taskModel.BacklogId);
            return View(taskModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .Include(t => t.Backlog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskModel = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskModelExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
