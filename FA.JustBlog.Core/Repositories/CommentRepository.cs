using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogDbContext dbContext) : base(dbContext)
        {

        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };

            _entitySet.Add(comment);
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _entitySet.Where(c => c.PostId == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return GetCommentsForPost(post.Id);
        }
    }
}
