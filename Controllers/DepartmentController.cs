using EXAMP.Entities;
using EXAMP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EXAMP.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;
        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        //Get: /<Controller>/
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            ViewBag.departments = departments;
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid) // validate
            {
                _context.Departments.Add(new Department { name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Department department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(new DepartmentEditModel { id = department.id, name = department.name });
        }

        [HttpPost]
        public IActionResult Edit(DepartmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(new Department
                {
                    id = model.id,
                    name = model.name
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Department department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

