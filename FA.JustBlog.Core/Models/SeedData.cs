using FA.JustBlog.Core.Models;
using System;


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
                    new Tag { Name = "#Programming", UrlSlug = "programming", Description = "Posts related to programming", Count = 0 },
                    new Tag { Name = "#Adventure", UrlSlug = "adventure", Description = "Posts related to adventure", Count = 0 },
                    new Tag { Name = "#Recipes", UrlSlug = "recipes", Description = "Posts related to recipes", Count = 0 },
                    new Tag { Name = "#World", UrlSlug = "world", Description = "Posts related to world", Count = 0 },
                    new Tag { Name = "#Local", UrlSlug = "local", Description = "Posts related to local", Count = 0 },
                    new Tag { Name = "#Business", UrlSlug = "business", Description = "Posts related to business", Count = 0 },
                    new Tag { Name = "#Media", UrlSlug = "media", Description = "Posts related to media", Count = 0 },
                    new Tag { Name = "#Technology", UrlSlug = "technology", Description = "Posts related to technology", Count = 0 },
                    new Tag { Name = "#Politic", UrlSlug = "politic", Description = "Posts related to politic", Count = 0 },
                    new Tag { Name = "#Education", UrlSlug = "education", Description = "Posts related to education", Count = 0 }
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
                    },
                    new Post
    {
        Title = "Getting Started with ASP.NET Core",
        ShortDescription = "Learn the basics of building web applications with ASP.NET Core.",
        ImageUrl = "aspnetcore.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "getting-started-with-aspnetcore",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-10),
        ViewCount = 50,
        RateCount = 10,
        TotalRate = 50,
        CategoryId = categories[0].Id
    },
    new Post
    {
        Title = "Mastering Entity Framework Core",
        ShortDescription = "Deep dive into Entity Framework Core for data access.",
        ImageUrl = "efcore.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "mastering-entity-framework-core",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-8),
        ViewCount = 200,
        RateCount = 10,
        TotalRate = 45,
        CategoryId = categories[0].Id
    },
    new Post
    {
        Title = "Building Responsive Web Design",
        ShortDescription = "Learn the principles of building responsive web designs.",
        ImageUrl = "responsive-design.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "building-responsive-web-design",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-15),
        ViewCount = 200,
        RateCount = 10,
        TotalRate = 39,
        CategoryId = categories[0].Id
    },
     new Post
    {
        Title = "Italian Pizza Varieties",
        ShortDescription = "Explore the world of authentic Italian pizzas.",
        ImageUrl = "italian-pizza.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "italian-pizza-varieties",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-8),
        ViewCount = 180,
        RateCount = 8,
        TotalRate = 40,
        CategoryId = categories[2].Id
    },
    new Post
    {
        Title = "Homemade Gelato Flavors",
        ShortDescription = "Create delicious gelato at home with these flavor ideas.",
        ImageUrl = "homemade-gelato.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "homemade-gelato-flavors",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-10),
        ViewCount = 150,
        RateCount = 7,
        TotalRate = 35,
        CategoryId = categories[2].Id
    },
    new Post
    {
        Title = "Tiramisu: A Classic Dessert",
        ShortDescription = "Learn to make the classic Italian dessert, Tiramisu.",
        ImageUrl = "tiramisu-dessert.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "tiramisu-a-classic-dessert",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-12),
        ViewCount = 200,
        RateCount = 9,
        TotalRate = 45,
        CategoryId = categories[2].Id
    },
    new Post
    {
        Title = "Hidden Gems of Vietnam",
        ShortDescription = "Explore the less-known treasures of Vietnam.",
        ImageUrl = "hidden-gems-vietnam.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "hidden-gems-vietnam",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-12),
        ViewCount = 180,
        RateCount = 8,
        TotalRate = 40,
        CategoryId = categories[1].Id
    },
    new Post
    {
        Title = "Thailand's Island Paradise",
        ShortDescription = "Discover the stunning islands of Thailand.",
        ImageUrl = "thailand-islands.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "thailand-island-paradise",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-15),
        ViewCount = 150,
        RateCount = 7,
        TotalRate = 35,
        CategoryId = categories[1].Id
    },
    new Post
    {
        Title = "Cultural Wonders of Cambodia",
        ShortDescription = "Immerse yourself in the rich culture of Cambodia.",
        ImageUrl = "cambodia-cultural-wonders.jpg",
        PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
        UrlSlug = "cambodia-cultural-wonders",
        Published = true,
        PublishedDate = DateTime.Now.AddDays(-18),
        ViewCount = 200,
        RateCount = 9,
        TotalRate = 45,
        CategoryId = categories[1].Id
    }

                };
                _context.Posts.AddRange(posts);
                _context.SaveChanges();

                //PostTagMap
                var postTagMaps = new List<PostTagMap>
               {
                    new PostTagMap { Post = posts[0], Tag = tags[0]},
                    new PostTagMap { Post = posts[0], Tag = tags[1]},
                    new PostTagMap { Post = posts[1], Tag = tags[1] },
                    new PostTagMap { Post = posts[2], Tag = tags[2] },
                    new PostTagMap { Post = posts[3], Tag = tags[3] },
                    new PostTagMap { Post = posts[4], Tag = tags[4] },
                    new PostTagMap { Post = posts[5], Tag = tags[5] },
                    new PostTagMap { Post = posts[6], Tag = tags[6] },      
                    new PostTagMap { Post = posts[7], Tag = tags[7] },  
                    new PostTagMap { Post = posts[8], Tag = tags[8] },
                    new PostTagMap { Post = posts[9], Tag = tags[9] },
                    new PostTagMap { Post = posts[10], Tag = tags[5] },
                    new PostTagMap { Post = posts[11], Tag = tags[7] }
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
