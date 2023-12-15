using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }

        ICategoryRepository CategoryRepository { get; }
        ICommentRepository CommentRepository { get; }

  

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
