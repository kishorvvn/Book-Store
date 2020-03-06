using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class SqlCategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext context;

        public SqlCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return context.Category.Include(a => a.CategoryName);
        }

        public Category GetCategory(int Id)
        {
            return context.Category.Find(Id);
        }
    }
}
