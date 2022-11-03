using Microsoft.EntityFrameworkCore;
using MyProject.Objects.DB;
using MyProject.Objects.Interfaces;
using MyProject.Objects.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Objects.Entity
{
  
        public class ProductEntity : IGetProducts
        {
            private readonly DataBase DB;

            public ProductEntity(DataBase DB)
            {
                this.DB = DB;
            }

            public IEnumerable<Products> IProducts => DB.Products.Include(c => c.Types);

            public IEnumerable<Products> IFavProducts => DB.Products.Where(p => p.OnMain).Include(c => c.Types);

        }
    
}
