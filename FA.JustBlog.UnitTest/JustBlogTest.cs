using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Core;
using System.ComponentModel.DataAnnotations;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.UnitTest
{
    public class JustBlogTest
    {
        private static DbContextOptions<JustBlogDbContext> _options
            = new DbContextOptionsBuilder<JustBlogDbContext>()
            .UseInMemoryDatabase(databaseName: "dbTests").Options;

        private JustBlogDbContext _dbContext;
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Category> categoryRepository;
        private IGenericRepository<Tag> tagRepository;
        private IGenericRepository<Post> postRepository;

        private ICategoryService categoryService;
        private IPostService postService;
        private ITagService tagService;
        private ICommentService commentService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new JustBlogDbContext(_options);
            var seedData = new SeedData(_dbContext);
            seedData.Seed();

            unitOfWork = new UnitOfWork(_dbContext);
            categoryRepository = new GenericRepository<Category>(_dbContext);
            tagRepository = new GenericRepository<Tag>(_dbContext);
            postRepository = new GenericRepository<Post>(_dbContext);

            categoryService = new CategoryService(unitOfWork);
            tagService = new TagService(unitOfWork);
            postService = new PostService(unitOfWork);
            commentService = new CommentService(unitOfWork);
        }

        //Test for CategoryService

        [Test]
        public void GetAll_GetAllCategories_ReturnAllCategories()
        {
            var categories = categoryService.GetAll();

            var expected = 3;

            Assert.That(categories.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InsertNewCategory()
        {
            var category = new Category()
            {
                Name = "Technology",
                UrlSlug = "technology",
                Description = "Posts related to technology"
            };

            categoryService.Add(category);

            var categories = categoryService.GetAll();

            var expected = 4;

            Assert.That(categories.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InvalidCategory_ThrowsValidationException()
        {
            var invalidCategory = new Category(); 

            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => categoryService.Add(invalidCategory));
        }

        [Test]
        public void Remove_DeleteCategoryById()
        {
            categoryService.Delete(2);

            var categories = categoryService.GetAll();

            var expected = 2;

            Assert.That(categories.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Remove_DeleteCategoryByEntity()
        {
            var category = categoryService.Find(1);

            categoryService.Delete(category);

            var categories = categoryService.GetAll();

            var expected = 2;

            Assert.That(categories.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Delete_NonExistingCategory_ThrowsEntityNotFoundException()
        {
            var nonExistingCategoryId = 999;
            Assert.Throws<EntityNotFoundException>(() => categoryService.Delete(nonExistingCategoryId));
        }

        [Test]
        public void Update_UpdateExistingCategory()
        {
            var newName = "Technology2";
            var newUrlSlug = "technology2";
            var newDescription = "Posts related to technology2";

            var category = categoryService.Find(1);
            category.Description = newDescription;
            category.Name = newName;
            category.UrlSlug = newUrlSlug;
            categoryService.Update(category);

            Assert.That(category.Name, Is.EqualTo("Technology2"));
        }

        [Test]
        public void Update_NonExistingCategory_ThrowsEntityNotFoundException()
        {
            var nonExistingCategory = new Category { Id = 999, Name = "NonExistingCategory" };
            Assert.Throws<DbUpdateConcurrencyException>(() => categoryService.Update(nonExistingCategory));
        }

        //Test for PostService

        [Test]
        public void GetAll_GetAllPosts_ReturnAllPosts()
        {
            var posts = postService.GetAll();

            var expected = 3;

            Assert.That(posts.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InsertNewPost()
        {
            var catagories = postService.GetAll();
            var post = new Post()
            {
                Title = "Introduction to HTML",
                ShortDescription = "Learn the basics of HTML programming language.",
                ImageUrl = "html.jpg",
                PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit...",
                UrlSlug = "introduction-to-html",
                Published = false,
                PublishedDate = DateTime.Now.AddDays(-7),
                ViewCount = 90,
                RateCount = 9,
                TotalRate = 54,
                CategoryId = catagories[0].Id
            };

            postService.Add(post);

            var posts = postService.GetAll();

            var expected = 4;

            Assert.That(posts.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InvalidPost_ThrowsValidationException()
        {
            var invalidPost = new Post(); 

            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => postService.Add(invalidPost));
        }

        [Test]
        public void Remove_DeletePostById()
        {
            postService.Delete(2);

            var posts = postService.GetAll();

            var expected = 2;

            Assert.That(posts.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Remove_DeletePostByEntity()
        {
            var post = postService.Find(1);

            postService.Delete(post);

            var posts = postService.GetAll();

            var expected = 2;

            Assert.That(posts.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Delete_NonExistingPost_ThrowsEntityNotFoundException()
        {
            var nonExistingPostId = 999;
            Assert.Throws<EntityNotFoundException>(() => postService.Delete(nonExistingPostId));
        }

        [Test]
        public void Update_UpdateExistingPost()
        {
            var newTitle = "Intro to HTML";
            var newImgUrl = "html.jpg";
            var newShortDescription = "How to master HTML";

            var post = postService.Find(3);
            post.ShortDescription = newShortDescription;
            post.Title = newTitle;
            post.ImageUrl = newImgUrl;
            postService.Update(post);

            Assert.That(post.Title, Is.EqualTo("Intro to HTML"));
        }

        [Test]
        public void Update_NonExistingPost_ThrowsEntityNotFoundException()
        {
            var nonExistingPost = new Post { Id = 999, Title = "NonExistingCategory" };
            Assert.Throws<DbUpdateConcurrencyException>(() => postService.Update(nonExistingPost));
        }

        [Test]
        public void GetPublisedPosts_ReturnsPublishedPosts()
        {
            var publishedPosts = postService.GetPublisedPosts();

            Assert.IsNotNull(publishedPosts);
            Assert.IsTrue(publishedPosts.All(post => post.Published));
        }

        [Test]
        public void FindPost_ExistingPost_ReturnsPost()
        {
            var result = postService.FindPost(2023, 11, "introduction-to-csharp");

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUnpublisedPosts_ReturnsUnpublishedPosts()
        {
            var result = postService.GetUnpublisedPosts();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(post => !post.Published));
        }

        [Test]
        public void GetLatestPost_ReturnsLatestPosts()
        {
            int size = 2; 
            var result = postService.GetLatestPost(size);

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(size));

            Assert.IsTrue(result.All(post => post.Published));
            Assert.IsTrue(result.SequenceEqual(result.OrderByDescending(post => post.PublishedDate)));
        }

        [Test]
        public void GetPostsByMonth_ReturnsPostsForGivenMonth()
        {
            DateTime monthYear = new DateTime(2023, 11, 1);

            var result = postService.GetPostsByMonth(monthYear);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(post => post.PublishedDate.Month == monthYear.Month && post.PublishedDate.Year == monthYear.Year));
        }

        [Test]
        public void CountPostsForCategory_ReturnsCorrectCount()
        {
            string category = "Technology";

            var result = postService.CountPostsForCategory(category);

            Assert.IsTrue(result > 0); 
        }

        [Test]
        public void GetPostsByCategory_ReturnsPostsForGivenCategory()
        {
            string category = "Technology";

            var result = postService.GetPostsByCategory(category);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(post => post.Category.Name == category));
        }

        [Test]
        public void CountPostsForTag_ReturnsCorrectCount()
        {
            string tag = "Programming";
            var result = postService.CountPostsForTag(tag);

            Assert.IsTrue(result >= 0); 
        }

        [Test]
        public void GetPostsByTag_ReturnsPostsForGivenTag()
        {
            string tag = "Programming";

            var result = postService.GetPostsByTag(tag);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(post => post.PostTags.Any(postTag => postTag.Tag.Name == tag)));
        }

        //Test for TagService

        [Test]
        public void GetAll_GetAllTags_ReturnAllTags()
        {
            var tags = tagService.GetAll();

            var expected = 3;

            Assert.That(tags.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InsertNewTag()
        {
            var tag = new Tag()
            {
                Name = "Introduction to music",
                Description = "Learn the basics of music.",
                UrlSlug = "music",
                Count = 7,
                
            };

            tagService.Add(tag);

            var tags = tagService.GetAll();

            var expected = 4;

            Assert.That(tags.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Add_InvalidTag_ThrowsValidationException()
        {
            var invalidTag = new Tag();

            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => tagService.Add(invalidTag));
        }

        [Test]
        public void Remove_DeleteTagById()
        {
            tagService.Delete(2);

            var tags = tagService.GetAll();

            var expected = 2;

            Assert.That(tags.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Remove_DeleteTagByEntity()
        {
            var tag = tagService.Find(1);

            tagService.Delete(tag);

            var tags = tagService.GetAll();

            var expected = 2;

            Assert.That(tags.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void Delete_NonExistingTag_ThrowsEntityNotFoundException()
        {
            var nonExistingTagId = 999;
            Assert.Throws<EntityNotFoundException>(() => tagService.Delete(nonExistingTagId));
        }

        [Test]
        public void Update_UpdateExistingTag()
        {
            var newName = "Music";
            var newUrlSlug = "music";
            var newDescription = "How to master HTML";

            var tag = tagService.Find(3);
            tag.Description = newDescription;
            tag.Name = newName;
            tag.UrlSlug = newUrlSlug;
            tagService.Update(tag);

            Assert.That(tag.Name, Is.EqualTo("Music"));
        }

        [Test]
        public void Update_NonExistingTag_ThrowsEntityNotFoundException()
        {
            var nonExistingTag = new Tag { Id = 999, Name = "NonExistingCategory" };
            Assert.Throws<DbUpdateConcurrencyException>(() => tagService.Update(nonExistingTag));
        }

        [Test]
        public void GetTagByUrlSlug_ReturnTagByUrlSlug()
        {
            var tag = tagService.GetTagByUrlSlug("recipes");

            Assert.IsNotNull(tag);
            Assert.That(tag.UrlSlug, Is.EqualTo("recipes"));
        }

        //Test for CommentService

        [Test]
        public void Add_ValidComment_AddsComment()
        {
            var comment = new Comment
            {
                Name = "Anonymous",
                Email = "anonymous2@example.com",
                CommentHeader = "Funny",
                CommentText = "This post is very funny. Thank you!",
                CommentTime = DateTime.Now.AddDays(-3),
                PostId = 1
            };

            commentService.Add(comment);

            Assert.That(commentService.GetAll().Count(), Is.EqualTo(4));
        }

        [Test]
        public void AddComment_ValidParameters_AddsComment()
        {
            var postId = 1;
            var commentName = "John Doe";
            var commentEmail = "john@example.com";
            var commentTitle = "Great post!";
            var commentBody = "I really enjoyed reading this post.";

            commentService.AddComment(postId, commentName, commentEmail, commentTitle, commentBody);

            Assert.That(commentService.GetAll().Count(), Is.EqualTo(4));
        }

        [Test]
        public void Delete_ExistingComment_RemovesComment()
        {
            var comment = commentService.Find(1);

            commentService.Delete(comment);

            Assert.That(commentService.GetAll().Count(), Is.EqualTo(2));
        }

        [Test]
        public void Delete_ExistingCommentId_RemovesComment()
        {
            var comment = commentService.Find(1);

            commentService.Delete(comment.Id);

            Assert.That(commentService.GetAll().Count(), Is.EqualTo(2));
        }

        [Test]
        public void Find_ExistingCommentId_ReturnsComment()
        {
            var comment = new Comment
            {
                Name = "Jane Doe",
                Email = "jane@example.com",
                CommentHeader = "Nice content",
                CommentText = "Your insights are valuable. Looking forward to more!",
                CommentTime = DateTime.Now.AddDays(-2),
                PostId = 2
            };
            commentService.Add(comment);

            var result = commentService.Find(comment.Id);

            Assert.That(result, Is.EqualTo(comment));
        }

        [Test]
        public void GetAll_ReturnsAllComments()
        {
            var result = commentService.GetAll();

            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetCommentsForPost_ExistingPostId_ReturnsCommentsForPost()
        {
            var postId = 1;
            var result = commentService.GetCommentsForPost(postId);

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetCommentsForPost_ExistingPost_ReturnsCommentsForPost()
        {
            var post = postService.Find(1);
            
            var result = commentService.GetCommentsForPost(post);

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Update_ExistingComment_UpdatesComment()
        {
            var comment = new Comment
            {
                Name = "Jane Doe",
                Email = "jane@example.com",
                CommentHeader = "Nice content",
                CommentText = "Your insights are valuable. Looking forward to more!",
                CommentTime = DateTime.Now.AddDays(-2),
                PostId = 2
            };
            commentService.Add(comment);

            comment.CommentText = "Updated comment text";
            commentService.Update(comment);

            Assert.That(comment.CommentText, Is.EqualTo("Updated comment text"));
        }


        [TearDown]
        public void Teardown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}