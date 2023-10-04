using EXAMP.Entities;
using EXAMP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace EXAMP.Controllers
{
    public class StaffController : Controller
    {
        private readonly DataContext _context;
        public StaffController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Staff> staffs = _context.Staffs.Include(p => p.department_id).ToList();

            return View(staffs);
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Create()
        {
            List<Department> departments = _context.Departments.ToList();
            var selectDepartments = new List<SelectListItem>();
            foreach (var c in departments)
            {
                selectDepartments.Add(new SelectListItem { Text = c.name, Value = c.id.ToString() });
            }
           

            ViewBag.departments = selectDepartments;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StaffViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Staffs.Add(new Staff
                {
                    name = model.name,
                    age = model.age,
                    email = model.email,
                    department_id = model.department_id,
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Department> departments = _context.Departments.ToList();
            var selectDepartments = new List<SelectListItem>();
            foreach (var c in departments)
            {
                selectDepartments.Add(new SelectListItem { Text = c.name, Value = c.id.ToString() });
            }


           
            ViewBag.departments = selectDepartments;

            return View();
        }
    }
}
