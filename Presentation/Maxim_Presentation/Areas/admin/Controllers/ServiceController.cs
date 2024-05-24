using Maxim_Application.Abstracts;
using Maxim_Domain.ModelViews;
using Maxim_Persistence.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maxim_Presentation.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class ServiceController : Controller
    {
        IServiceSlider _service;
        private readonly IWebHostEnvironment _environment;

        public ServiceController(IServiceSlider service,IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceSliderVM serviceSliderVM)
        {
            if (!ModelState.IsValid) { return View(); }
            if (!serviceSliderVM.ImgFile.Checker())
            {
                ModelState.AddModelError("ImgFile", "must be image type and nt larger than 2 mb");
                return View();
            }
            string envpath=_environment.WebRootPath;
            string filename = serviceSliderVM.ImgFile.Create(envpath,@"\upload\services\",serviceSliderVM.ImgFile.FileName);
            _service.Create(serviceSliderVM, filename);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var delete=_service.GetSlider(id);
            string envpath = _environment.WebRootPath;
            delete.Delete(envpath, @"\upload\services\", delete.ImgUrl);
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var old=_service.GetSlider(id);
            ServiceSliderVM serviceSliderVM = new ServiceSliderVM()
            {
                Description=old.Description,
                Title=old.Title,
            };
            return View(serviceSliderVM);
        }
        [HttpPost]
        public IActionResult Update(ServiceSliderVM serviceSliderVM)
        {
            if (!ModelState.IsValid) { return View(); }
            if(!serviceSliderVM.ImgFile.Checker()) 
            {
                ModelState.AddModelError("ImgFile", "must be image type and nt larger than 2 mb");
                return View();
            }
            var old=_service.GetSlider(serviceSliderVM.Id);
            string envpath= _environment.WebRootPath;
            string filename=serviceSliderVM.ImgFile.Update(envpath, @"\upload\services\", old.ImgUrl, serviceSliderVM.ImgFile.FileName);
            _service.Update(serviceSliderVM, filename);
            return RedirectToAction("Index");
        }
    }
}
