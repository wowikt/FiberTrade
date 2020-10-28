using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FifteenGameAspNet.Models
{
    public class DialogViewModel
    {
        [Required(ErrorMessage ="Представьтесь, пожалуйста")]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}