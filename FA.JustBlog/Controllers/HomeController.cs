using FA.JustBlog.Core;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ITagService _tagService;
		public HomeController(ILogger<HomeController> logger, ITagService tagService)
		{
			_logger = logger;
			_tagService = tagService;
		}

		public IActionResult Index()
        {
			var tag = _tagService.GetTopTags();

			var tagVm = new List<TagViewModel>();
			if (tag != null)
			{
				foreach (var item in tag)
				{
					tagVm.Add(new TagViewModel()
					{
						Id = item.Id,
						Name = item.Name,
						UrlSlug = item.UrlSlug,
						Description = item.Description,
						Count = item.Count
					});
				}
			}
			TempData["Tags"] = tagVm;
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}