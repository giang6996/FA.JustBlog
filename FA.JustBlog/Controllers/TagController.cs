using FA.JustBlog.Core;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        public IActionResult Index()
        {
            var tags = _tagService.GetAll();
            var tagVms = new List<TagViewModel>();
            foreach (var tag in tags)
            {
                tagVms.Add(new TagViewModel()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    UrlSlug = tag.UrlSlug,
                    Description = tag.Description,
                    Count = tag.Count,
                });
            }
            return View(tagVms);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string urlSlug, string description, int count)
        {
            _tagService.Add(new Tag()
            {
                Name = name,
                UrlSlug = urlSlug,
                Description = description,
                Count = count
            });
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            try
            {
                var tag = _tagService.Find(id);
                if (tag != null)
                {
                    var tagVms = new TagViewModel()
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        UrlSlug = tag.UrlSlug,
                        Description = tag.Description,
                        Count= tag.Count
                    };
                    return View(tagVms);
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
                var tag = _tagService.Find(id);
                if (tag != null)
                {
                    var tagModel = new TagViewModel()
                    {
                        Name = tag.Name,
                        UrlSlug = tag.UrlSlug,
                        Description = tag.Description,
                        Count = tag.Count
                    };
                    return View(tagModel);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TagViewModel tagViewModel)
        {
            try
            {
                var tag = new Tag()
                {
                    Id = id,
                    Name = tagViewModel.Name,
                    Description = tagViewModel.Description,
                    UrlSlug = tagViewModel.UrlSlug,
                    Count = tagViewModel.Count
                };

                _tagService.Update(tag);


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
                var tag = _tagService.Find(id);
                if (tag != null)
                    _tagService.Delete(tag);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}
