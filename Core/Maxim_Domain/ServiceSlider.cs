using Maxim_Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Domain
{
    public class ServiceSlider:BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Description { get; set; }
        
        [MinLength(1)]
        [MaxLength(100)]
        public string? ImgUrl { get; set; }
    }
}
