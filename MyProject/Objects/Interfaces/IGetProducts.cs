using MyProject.Objects.Models;
using System.Collections.Generic;

namespace MyProject.Objects.Interfaces
{
    public interface IGetProducts
    {
       
            IEnumerable<Products> IProducts { get; }
            IEnumerable<Products> IFavProducts { get; }

      
    }
}
