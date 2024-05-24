
using Maxim_Application.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maxim_Presentation.Controllers
{
    public class HomeController : Controller
    {
        IServiceSlider _service;

        public HomeController(IServiceSlider slider)
        {
            _service = slider;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }  
    }
}
