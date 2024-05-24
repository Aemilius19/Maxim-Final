using Maxim_Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Domain.ModelViews
{
    public class ServiceSliderVM:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImgFile { get; set; }
    }  
}
