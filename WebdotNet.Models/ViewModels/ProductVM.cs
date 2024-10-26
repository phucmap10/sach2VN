using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebdotNet.Models.ViewModels
{
    public class ProductVM
    {
        public Products Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
