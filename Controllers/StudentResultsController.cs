using Microsoft.AspNetCore.Mvc;
using StudentResultsApp.Data;
using StudentResultsApp.Models;

namespace StudentResultsApp.Controllers
{
    public class StudentResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string statusFilter)
        {
            var results = _context.StudentResults.AsQueryable();

            if (string.IsNullOrEmpty(statusFilter))
            {
                statusFilter = "All";
            }

            if (statusFilter != "All")
            {
                if (Enum.TryParse(statusFilter, out Status parsedStatus))
                {
                    results = results.Where(r => r.Status == parsedStatus);
                }
            }

            // Always assign this
            ViewBag.StatusFilter = statusFilter;

            return View(results.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentResult studentResult)
        {
            if (ModelState.IsValid)
            {
                studentResult.Status = studentResult.TotalMarks switch
                {
                    < 50 => Status.NeedsImprovement,
                    < 80 => Status.Good,
                    _ => Status.Excellent
                };
                _context.Add(studentResult);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(studentResult);

        }
    }
    
    
}
