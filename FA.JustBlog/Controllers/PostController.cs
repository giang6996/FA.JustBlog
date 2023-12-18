﻿using Microsoft.AspNetCore.Mvc;
using FA.JustBlog.Core;
using FA.JustBlog.Models;
using System.Security.Policy;
using Humanizer.Localisation;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var posts = _postService.GetAll();

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
            return View(postVms);
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

        public ActionResult DetailDate(int year, int month, string title)
        {
            var post = _postService.FindPost(year, month, title);
            if (post != null)
            {
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
            return View();  

            
        }

        public IActionResult LatestPost()
        {
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
            return View(sortedposts);
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

                _postService.Add(new Post() {
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
                var postVm = new PostViewModel() { 
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    ImageUrl = post.ImageUrl,
                    PostContent = post.PostContent,
                    UrlSlug =post.UrlSlug,
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, string title, string shortDescription, int categoryId)
        //{
        //    try
        //    {
        //        var findPost = _postService.Find(id);
        //        if (findPost != null)
        //        {
        //            findPost.Id = id;
        //            findPost.Title = title;
        //            findPost.ShortDescription = shortDescription;
        //            findPost.CategoryId = categoryId;

        //        _postService.Update(findPost);
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
    }
}
