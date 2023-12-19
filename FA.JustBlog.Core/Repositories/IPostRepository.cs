using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Post FindPost(int year, int month, string urlSlug);
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost(int size);
        IList<Post> GetLatestPost();
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);

        IList<Post> GetPostsByCategory(int id);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
    }
}
