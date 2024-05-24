using Maxim_Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_Domain.ModelViews
{
    public class RegisterVM:BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
    }
}
