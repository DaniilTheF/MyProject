using System.Collections.Generic;
using MyProject.Objects.Models;

namespace MyProject.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Products> getProducts { get; set; }
        public string currentTypeLoccation { get; set; }
    }
}
