using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogDbContext dbContext) : base(dbContext)
        {
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            // Implement logic to find post by year, month, and urlSlug
            return _entitySet
                .Where(p => p.PublishedDate.Year == year && p.PublishedDate.Month == month && p.UrlSlug == urlSlug).FirstOrDefault();
        }

        public IList<Post> GetPublisedPosts()
        {
            // Implement logic to get published posts
            return _entitySet.Where(p => p.Published).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            // Implement logic to get unpublished posts
            return _entitySet.Where(p => !p.Published).ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
            // Implement logic to get the latest posts
            return _entitySet.Where(p => p.Published).OrderByDescending(p => p.PublishedDate).Take(size).ToList();
        }

        public IList<Post> GetLatestPost()
        {
            // Implement logic to get the latest posts
            return _entitySet.Where(p => p.Published).OrderByDescending(p => p.PublishedDate).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            // Implement logic to get posts by month and year
            return _entitySet
                .Where(p => p.PublishedDate.Month == monthYear.Month && p.PublishedDate.Year == monthYear.Year)
                .ToList();
        }

        public int CountPostsForCategory(string category)
        {
            // Implement logic to count posts for a category
            return _entitySet.Count(p => p.Category.Name == category);
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            // Implement logic to get posts by category
            return _entitySet.Where(p => p.Category.Name == category).ToList();
        }

        public int CountPostsForTag(string tag)
        {
            // Implement logic to count posts for a tag
            return _entitySet.Count(p => p.PostTags.Any(pt => pt.Tag.Name == tag));
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            // Implement logic to get posts by tag
            return _entitySet.Where(p => p.PostTags.Any(pt => pt.Tag.Name == tag)).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            // Implement logic to get the most viewed posts
            return _entitySet.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            // Implement logic to get the highest-rated posts
            return _dbContext.Posts.OrderByDescending(p => p.Rate).Take(size).ToList();
        }
    }

}
