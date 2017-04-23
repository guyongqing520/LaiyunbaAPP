using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.Tests.Classes
{
    class EntityWithValidationAttribute
    {
        [Required(ErrorMessage = "This is a required property")]
        public string RequiredProperty { get; set; }
    }
}
