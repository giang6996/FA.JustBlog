using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogDbContext dbContext) : base(dbContext)
        {

        }

        public Category GetByName(string name)
        {
            return _entitySet
                .Where(p => p.Name == name).FirstOrDefault();
        }


    }
}
