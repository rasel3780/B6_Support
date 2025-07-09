using AutoMapperDemo.Models;
using AutoMapperDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDemo.Controllers
{
    public class DemoController : Controller
    {
        private readonly DemoService _service;
        public DemoController(DemoService demoService)
        {
            _service = demoService;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel
            {
                TotalStudents = await _service.CountTotalStudent(),
                AdminCount = await _service.CountAdmin(),
                MaxSalary = await _service.GetMaxSalary(),
                MinSalary = await _service.GetMinSalary(),
                AvgSalary = await _service.GetAvgSalary(),
                HasAtLeastOneProduct = await _service.HasAtleastOneProduct(),
                IsCourseExist = await _service.IsCourseExist(),
                ProductsByCategory = await _service.GetProductInCategory("Electronics"),
                AllStudentWithCourse = await _service.GetAllStudentWithCourse()
            };
            return View(viewModel);
        }
    }
}
