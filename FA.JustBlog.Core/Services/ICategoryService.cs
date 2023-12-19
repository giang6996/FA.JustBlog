using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public interface ICategoryService
    {
        IList<Category> GetAll();

        Category FindByName(string name);
        Category Find(int id);
        void Add(Category category);

        void Update(Category category);
        void Delete(Category category);

        void Delete(int id);
    }
}
