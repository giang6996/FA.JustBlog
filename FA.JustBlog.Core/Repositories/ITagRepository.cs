using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);

    }
}
