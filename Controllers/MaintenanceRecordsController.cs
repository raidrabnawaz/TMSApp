using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMSApp.Data;
using TMSApp.Models;

namespace TMSApp.Controllers
{
    [Authorize]
    public class MaintenanceRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaintenanceRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MaintenanceRecords.Include(m => m.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MaintenanceRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceRecord = await _context.MaintenanceRecords
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (maintenanceRecord == null)
            {
                return NotFound();
            }

            return View(maintenanceRecord);
        }

        // GET: MaintenanceRecords/Create
        public IActionResult Create()
        {
            ViewData["VehicleList"] = new SelectList(_context.Vehicles.Select(v => new
            {
                v.VehicleID,
                DisplayName = $"{v.LicensePlate} - {v.Type} {v.Make} {v.Model}"
            }), "VehicleID", "DisplayName");
            return View();
        }

        // POST: MaintenanceRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VehicleID,ActivityType,Date,Cost,Notes")] MaintenanceRecord maintenanceRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleList"] = new SelectList(_context.Vehicles.Select(v => new
            {
                v.VehicleID,
                DisplayName = $"{v.LicensePlate} - {v.Type} {v.Make} {v.Model}"
            }), "VehicleID", "DisplayName", maintenanceRecord.VehicleID);
            return View(maintenanceRecord);
        }

        // GET: MaintenanceRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceRecord = await _context.MaintenanceRecords.FindAsync(id);
            if (maintenanceRecord == null)
            {
                return NotFound();
            }
            ViewData["VehicleList"] = new SelectList(_context.Vehicles.Select(v => new
            {
                v.VehicleID,
                DisplayName = $"{v.LicensePlate} - {v.Type} {v.Make} {v.Model}"
            }), "VehicleID", "DisplayName", maintenanceRecord.VehicleID);
            return View(maintenanceRecord);
        }

        // POST: MaintenanceRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VehicleID,ActivityType,Date,Cost,Notes")] MaintenanceRecord maintenanceRecord)
        {
            if (id != maintenanceRecord.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceRecordExists(maintenanceRecord.ID))
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
            ViewData["VehicleList"] = new SelectList(_context.Vehicles.Select(v => new
            {
                v.VehicleID,
                DisplayName = $"{v.LicensePlate} - {v.Type} {v.Make} {v.Model}"
            }), "VehicleID", "DisplayName", maintenanceRecord.VehicleID);
            return View(maintenanceRecord);
        }

        // GET: MaintenanceRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceRecord = await _context.MaintenanceRecords
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (maintenanceRecord == null)
            {
                return NotFound();
            }

            return View(maintenanceRecord);
        }

        // POST: MaintenanceRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceRecord = await _context.MaintenanceRecords.FindAsync(id);
            if (maintenanceRecord != null)
            {
                _context.MaintenanceRecords.Remove(maintenanceRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceRecordExists(int id)
        {
            return _context.MaintenanceRecords.Any(e => e.ID == id);
        }
    }
}
