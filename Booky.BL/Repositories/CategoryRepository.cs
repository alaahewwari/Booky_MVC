using Booky.BL.Interfaces;
using Booky.DAL.Data;
using Booky.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.BL.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(BookyDbContext context) : base(context)
        {

        }
    }
}
