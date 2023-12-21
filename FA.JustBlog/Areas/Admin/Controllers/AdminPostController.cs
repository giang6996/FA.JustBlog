using FA.JustBlog.Core;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using Newtonsoft.Json;


namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class AdminPostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public AdminPostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int? page, int postCategory = 0, string title = "abcd")
        {
            IList<Post> posts;
            int pageNum = page ?? 1;
            int pageSize = 3;
            var category = _categoryService.GetAll();
            var categoryVms = new List<CategoryViewModel>();
            foreach (var item in category)
            {
                categoryVms.Add(new CategoryViewModel()     
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            TempData["AdminCategorys"] = JsonConvert.SerializeObject(categoryVms);



            if (postCategory != 0)
            {
                posts = _postService.GetPostsByCategory(postCategory);

            }
            else if (title != "abcd")
            {
                posts = _postService.SearchByTitle(title);
            }
            else
            {
                posts = _postService.GetAll();
            }

            TempData["CategoryName"] = postCategory;
            TempData["PostSearchName"] = title;

            var postVms = new List<PostViewModel>();
            foreach (var post in posts)
            {
                postVms.Add(new PostViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    ImageUrl = post.ImageUrl,
                    PostContent = post.PostContent,
                    UrlSlug = post.UrlSlug,
                    Published = post.Published,
                    PublishedDate = post.PublishedDate,
                    ViewCount = post.ViewCount,
                    RateCount = post.RateCount,
                    TotalRate = post.TotalRate,
                    CategoryId = post.CategoryId,
                });
            }
            return View(postVms.ToPagedList(pageNum, pageSize));
        }


        public ActionResult Detail(int id)
        {
            var post = _postService.Find(id);
            var postVm = new PostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                ImageUrl = post.ImageUrl,
                PostContent = post.PostContent,
                UrlSlug = post.UrlSlug,
                Published = post.Published,
                PublishedDate = post.PublishedDate,
                ViewCount = post.ViewCount,
                RateCount = post.RateCount,
                TotalRate = post.TotalRate,
                CategoryId = post.CategoryId,
            };
            return View(postVm);
        }

        

        public IActionResult LatestPost(int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 3;

            IList<Post> sortedposts = _postService.GetLatestPost();

            List<Post> postVms = new List<Post>();
            foreach (var post in sortedposts)
            {
                postVms.Add(new Post()
                {
                    Id = post.Id,
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    ImageUrl = post.ImageUrl,
                    PostContent = post.PostContent,
                    UrlSlug = post.UrlSlug,
                    Published = post.Published,
                    PublishedDate = post.PublishedDate,
                    ViewCount = post.ViewCount,
                    RateCount = post.RateCount,
                    TotalRate = post.TotalRate,
                    CategoryId = post.CategoryId,
                });
            }

            return View(postVms.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var title = collection["Title"].ToString();
                var shortDescription = collection["ShortDescription"].ToString();
                var imageUrl = collection["ImageUrl"].ToString();
                var postContent = collection["PostContent"].ToString();
                var urlSlug = collection["UrlSlug"].ToString();
                var viewCount = collection["ViewCount"].ToString();
                var rateCount = collection["RateCount"].ToString();
                var totalRate = collection["TotalRate"].ToString();
                var categoryId = collection["CategoryId"].ToString();

                _postService.Add(new Post()
                {
                    Title = title,
                    ShortDescription = shortDescription,
                    ImageUrl = imageUrl,
                    UrlSlug = urlSlug,
                    PostContent = postContent,
                    Published = true,
                    PublishedDate = DateTime.Now,
                    ViewCount = int.Parse(viewCount),
                    RateCount = int.Parse(rateCount),
                    TotalRate = int.Parse(totalRate),
                    CategoryId = int.Parse(categoryId)
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var post = _postService.Find(id);
                var postVm = new PostViewModel()
                {
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    ImageUrl = post.ImageUrl,
                    PostContent = post.PostContent,
                    UrlSlug = post.UrlSlug,
                    Published = post.Published,
                    PublishedDate = post.PublishedDate,
                    ViewCount = post.ViewCount,
                    RateCount = post.RateCount,
                    TotalRate = post.TotalRate,
                    CategoryId = post.CategoryId
                };

                if (postVm != null)
                {
                    return View(postVm);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostViewModel postVm)
        {
            try
            {
                var post = new Post()
                {
                    Id = id,
                    Title = postVm.Title,
                    ShortDescription = postVm.ShortDescription,
                    ImageUrl = postVm.ImageUrl,
                    PostContent = postVm.PostContent,
                    UrlSlug = postVm.UrlSlug,
                    Published = postVm.Published,
                    PublishedDate = postVm.PublishedDate,
                    ViewCount = postVm.ViewCount,
                    RateCount = postVm.RateCount,
                    TotalRate = postVm.TotalRate,
                    CategoryId = postVm.CategoryId,

                };

                _postService.Update(post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            try
            {
                var post = _postService.Find(id);
                if (post != null)
                    _postService.Delete(post);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        public ActionResult PostsByTag(string tagName, int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 3;

            var posts = _postService.GetPostsByTag(tagName);

            var postVms = new List<PostViewModel>();
            foreach (var post in posts)
            {
                postVms.Add(new PostViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    ImageUrl = post.ImageUrl,
                    PostContent = post.PostContent,
                    UrlSlug = post.UrlSlug,
                    Published = post.Published,
                    PublishedDate = post.PublishedDate,
                    ViewCount = post.ViewCount,
                    RateCount = post.RateCount,
                    TotalRate = post.TotalRate,
                    CategoryId = post.CategoryId,
                });
            }

            return View(postVms.ToPagedList(pageNum, pageSize));
        }
    }
}
