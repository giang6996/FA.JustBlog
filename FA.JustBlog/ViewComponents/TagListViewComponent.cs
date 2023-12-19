using Microsoft.AspNetCore.Mvc;
using FA.JustBlog.Models;
using FA.JustBlog.Core;

namespace FA.JustBlog.ViewComponents
{
	public class TagListViewComponent : ViewComponent
	{
		private readonly ITagService _tagService;

        public TagListViewComponent(ITagService tagService)
        {
            _tagService = tagService;
        }

		public IViewComponentResult Invoke()
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

			return View(tagVm);
		}
	}
}
