using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Models;

namespace SampleWebApplication.Data
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;    
        }

        // GET: Students
        [HttpGet]
        public ActionResult Index()
        {


            return View(_context.Set<Students>().OrderBy(model => model.FirstMidName));
        }

        //public async Task<IActionResult> Index()
        //{
          //return View(await _context.Students.ToListAsync());
        //}

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                //Include will cause the context to load Students.Enrollments navigation property
                .Include(s => s.Enrollments)
                    //Then Include Enrollment.Course navigation property
                    .ThenInclude(e => e.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Students students)
        {
            if (id != students.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .SingleOrDefaultAsync(m => m.ID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }

        public ActionResult Save()
        {
            return View();
        }

        //Save Method
        [HttpPost]
        public ActionResult Save(Students students)
        {
            _context.Update(students);
            try
            {
                // Attempt to save changes to the database
                _context.SaveChanges();
                return View(students);
            }
                catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

           
        }
    }
}
