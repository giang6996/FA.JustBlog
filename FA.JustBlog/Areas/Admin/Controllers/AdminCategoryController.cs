﻿
using FA.JustBlog.Core;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categorys = _categoryService.GetAll();
            var categoryVms = new List<CategoryViewModel>();
            foreach (var category in categorys)
            {
                categoryVms.Add(new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlSlug = category.UrlSlug,
                    Description = category.Description,
                });
            }

            return View(categoryVms);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string urlSlug, string description)
        {
            _categoryService.Add(new Category()
            {
                Name = name,
                UrlSlug = urlSlug,
                Description = description
            });
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            try
            {
                var category = _categoryService.Find(id);
                if (category != null)
                {
                    var categoryVms = new CategoryViewModel()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        UrlSlug = category.UrlSlug,
                        Description = category.Description,
                    };
                    return View(categoryVms);
                }
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        


        public ActionResult Edit(int id)
        {
            try
            {
                var category = _categoryService.Find(id);
                if (category != null)
                {
                    var categoryModel = new CategoryViewModel()
                    {
                        Name = category.Name,
                        UrlSlug = category.UrlSlug,
                        Description = category.Description
                    };
                    return View(categoryModel);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {
            try
            {
                var category = new Category()
                {
                    Id = id,
                    Name = categoryViewModel.Name,
                    Description = categoryViewModel.Description,
                    UrlSlug = categoryViewModel.UrlSlug,
                };

                _categoryService.Update(category);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult _CategoryDropdown()
        {
            var category = _categoryService.GetAll();

            var categoryVm = new List<CategoryViewModel>();
            if (category != null)
            {
                foreach (var item in category)
                {
                    categoryVm.Add(new CategoryViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                    });
                }
            }

            return PartialView(categoryVm);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var category = _categoryService.Find(id);
                if (category != null)
                    _categoryService.Delete(category);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}
