using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<JustBlogDbContext>();
optionsBuilder.UseSqlServer("server=.;database=JustBlogDb2;Trusted_connection=True;" +
               "TrustServerCertificate=True");

using (JustBlogDbContext dbContext = new JustBlogDbContext(optionsBuilder.Options))
{
    dbContext.Database.EnsureCreated();
    IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
    ICategoryService categoryService = new CategoryService(unitOfWork);
    IPostService postService = new PostService(unitOfWork);
    ITagService tagService = new TagService(unitOfWork);

    ICommentService commentService = new CommentService(unitOfWork);

    var seedData = new SeedData(dbContext);
    seedData.Seed();

    var categories = categoryService.GetAll();
    foreach (var category in categories)
    {
        Console.WriteLine($"{category.Id} | {category.Name} | {category.Description} | {category.UrlSlug}");
    }
}