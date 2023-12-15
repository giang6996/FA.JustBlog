using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogDbContext dbContext) : base(dbContext)
        {
        }
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _dbContext.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

    }
}
