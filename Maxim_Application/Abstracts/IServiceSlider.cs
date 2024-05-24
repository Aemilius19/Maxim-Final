using Maxim_Domain;
using Maxim_Domain.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Application.Abstracts
{
    public interface IServiceSlider
    {

        List<ServiceSlider> GetAll();
        ServiceSlider GetSlider(int index);

        void Create(ServiceSliderVM slidervm,string filename);

        void Delete(int id);

        void Update(ServiceSliderVM slidervm, string filename);
        
    }
}
