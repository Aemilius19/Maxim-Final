using Maxim_Application.Abstracts;
using Maxim_Domain;
using Maxim_Domain.ModelViews;
using Maxim_Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Persistence.Concretes
{
    public class SliderService : IServiceSlider
    {
        AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(ServiceSliderVM slidervm, string filename)
        {
            ServiceSlider slider=new ServiceSlider()
            {
                Title=slidervm.Title,
                Description=slidervm.Description,
                ImgUrl=filename
            };
            _context.ServiceSliders.Add(slider);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete=_context.ServiceSliders.FirstOrDefault(x=>x.Id == id);
            if (delete == null)
            {
                throw new Exception("slider tapilmadi");
            }
            _context.ServiceSliders.Remove(delete);
            _context.SaveChanges();
        }

        public List<ServiceSlider> GetAll()
        {
            return _context.ServiceSliders.ToList();
        }

        public ServiceSlider GetSlider(int id)
        {
            return _context.ServiceSliders.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ServiceSliderVM slidervm, string filename)
        {
            var update=_context.ServiceSliders.FirstOrDefault(x=>x.Id==slidervm.Id);
            update.Title=slidervm.Title;
            update.Description=slidervm.Description;
            update.ImgUrl=filename;
            _context.SaveChanges();
        }
    }
}
