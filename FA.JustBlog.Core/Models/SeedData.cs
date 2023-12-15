using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace FA.JustBlog.Core
{
    public class SeedData
    {
        private readonly JustBlogDbContext _context;

        public SeedData(JustBlogDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Seed()
        {
            if (!_context.Categories.Any())
            {
                // Categories
                var categories = new List<Category>
                {
                    new Category { Name = "Technology", UrlSlug = "technology", Description = "Posts related to technology" },
                    new Category { Name = "Travel", UrlSlug = "travel", Description = "Posts related to travel" },
                    new Category { Name = "Cooking", UrlSlug = "cooking", Description = "Posts related to cooking" }
                };
                _context.Categories.AddRange(categories);
                _context.SaveChanges();


                // Tags
                var tags = new List<Tag>
                {
                    new Tag { Name = "Programming", UrlSlug = "programming", Description = "Posts related to programming", Count = 0 },
                    new Tag { Name = "Adventure", UrlSlug = "adventure", Description = "Posts related to adventure", Count = 0 },
                    new Tag { Name = "Recipes", UrlSlug = "recipes", Description = "Posts related to recipes", Count = 0 }
                };
                _context.Tags.AddRange(tags);
                _context.SaveChanges();

                // Posts
                var posts = new List<Post>
                {
                    new Post
                    {
                        Title = "Introduction to C#",
                        ShortDescription = "Learn the basics of C# programming language.",
                        ImageUrl = "csharp.jpg",
                        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
                        UrlSlug = "introduction-to-csharp",
                        Published = true,
                        PublishedDate = DateTime.Now.AddDays(-7),
                        ViewCount = 100,
                        RateCount = 5,
                        TotalRate = 25,
                        CategoryId = categories[0].Id  
                    },
                    new Post
                    {
                        Title = "Exploring Southeast Asia",
                        ShortDescription = "Discover the beauty of Southeast Asia.",
                        ImageUrl = "southeast-asia.jpg",
                        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
                        UrlSlug = "exploring-southeast-asia",
                        Published = true,
                        PublishedDate = DateTime.Now.AddDays(-10),
                        ViewCount = 150,
                        RateCount = 7,
                        TotalRate = 35,
                        CategoryId = categories[1].Id
                    },
                    new Post
                    {
                        Title = "Delicious Pasta Recipes",
                        ShortDescription = "Try these mouth-watering pasta recipes at home.",
                        ImageUrl = "pasta-recipes.jpg",
                        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
                        UrlSlug = "delicious-pasta-recipes",
                        Published = true,
                        PublishedDate = DateTime.Now.AddDays(-5),
                        ViewCount = 120,
                        RateCount = 6,
                        TotalRate = 30,
                        CategoryId = categories[2].Id
                    }
                };
                _context.Posts.AddRange(posts);
                _context.SaveChanges();

                //PostTagMap
               var postTagMaps = new List<PostTagMap>
               {
                    new PostTagMap { PostId = posts[0].Id, TagId = tags[0].Id },
                    new PostTagMap { PostId = posts[1].Id, TagId = tags[1].Id },
                    new PostTagMap { PostId = posts[2].Id, TagId = tags[2].Id }
               };
                _context.PostTags.AddRange(postTagMaps);

                _context.SaveChanges();


                // Comment
                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Name = "John Doe",
                        Email = "john@example.com",
                        CommentHeader = "Great post!",
                        CommentText = "I really enjoyed reading this post. Thanks for sharing!",
                        CommentTime = DateTime.Now.AddDays(-1), 
                        PostId = posts[2].Id
                    },
                    new Comment
                    {
                        Name = "Jane Doe",
                        Email = "jane@example.com",
                        CommentHeader = "Nice content",
                        CommentText = "Your insights are valuable. Looking forward to more!",
                        CommentTime = DateTime.Now.AddDays(-2), 
                        PostId = posts[0].Id
                    },
                    new Comment
                    {
                        Name = "Anonymous",
                        Email = "anonymous@example.com",
                        CommentHeader = "Interesting",
                        CommentText = "This post has given me a new perspective. Thank you!",
                        CommentTime = DateTime.Now.AddDays(-3), 
                        PostId = posts[1].Id
                    }
                };
                _context.Comments.AddRange(comments);

                _context.SaveChanges();

            }
        }

    }

}
