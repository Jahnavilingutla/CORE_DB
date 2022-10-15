using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_DB.Models;
using NToastNotify;

namespace CORE_DB.Controllers
{
    public class ItEmpDetailsController : Controller
    {
        private readonly COREContext _context;
        private readonly ILogger<ItEmpDetailsController> _logger;
        private readonly IToastNotification _toastNotification;

        public ItEmpDetailsController(ILogger<ItEmpDetailsController> logger, IToastNotification toastNotification, COREContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: ItEmpDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.ItEmpDetails.ToListAsync());
        }

        // GET: ItEmpDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItEmpDetails == null)
            {
                return NotFound();
            }

            var itEmpDetail = await _context.ItEmpDetails
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (itEmpDetail == null)
            {
                return NotFound();
            }

            return View(itEmpDetail);
        }

        // GET: ItEmpDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItEmpDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeeSal,Doj")] ItEmpDetail itEmpDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itEmpDetail);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Employee created successfully");
                return RedirectToAction(nameof(Index));
            }
            return View(itEmpDetail);
        }

        // GET: ItEmpDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItEmpDetails == null)
            {
                return NotFound();
            }

            var itEmpDetail = await _context.ItEmpDetails.FindAsync(id);
            if (itEmpDetail == null)
            {
                return NotFound();
            }
            return View(itEmpDetail);
        }

        // POST: ItEmpDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,EmployeeSal,Doj")] ItEmpDetail itEmpDetail)
        {
            if (id != itEmpDetail.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itEmpDetail);
                    _toastNotification.AddWarningToastMessage("Employee updated successfully");
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItEmpDetailExists(itEmpDetail.EmployeeId))
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
            return View(itEmpDetail);
        }

        // GET: ItEmpDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItEmpDetails == null)
            {
                return NotFound();
            }

            var itEmpDetail = await _context.ItEmpDetails
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (itEmpDetail == null)
            {
                return NotFound();
            }

            return View(itEmpDetail);
        }

        // POST: ItEmpDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItEmpDetails == null)
            {
                return Problem("Entity set 'COREContext.ItEmpDetails'  is null.");
            }
            var itEmpDetail = await _context.ItEmpDetails.FindAsync(id);
            if (itEmpDetail != null)
            {
                _context.ItEmpDetails.Remove(itEmpDetail);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddErrorToastMessage("Employee deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool ItEmpDetailExists(int id)
        {
          return _context.ItEmpDetails.Any(e => e.EmployeeId == id);
        }
    }
}
