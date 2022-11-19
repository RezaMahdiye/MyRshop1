using MyRshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShow();
    }

    public class GroupRepository : IGroupRepository
    {
        private MyRshopContext _context; 

        public GroupRepository(MyRshopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
           return  _context.Categories.Select(c => new ShowGroupViewModel()
           {
               GroupId = c.Id,
               Name = c.Name,
               Productcount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
           }).ToList();
        }
    }
}
