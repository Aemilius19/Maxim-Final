using Maxim_Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Domain.ModelViews
{
    public class LoginVM:BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string UserNameorEmail{ get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
