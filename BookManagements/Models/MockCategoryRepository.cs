using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categoryList;

        public MockCategoryRepository(List<Category> categoryList)
        {
            _categoryList = categoryList;
        }
      
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryList;
        }

        public Category GetCategory(int Id)
        {
            return _categoryList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
