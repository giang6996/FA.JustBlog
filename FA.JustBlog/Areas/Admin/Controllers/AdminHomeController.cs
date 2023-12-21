using FA.JustBlog.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ILogger<AdminHomeController> _logger;
        //private readonly ITagService _tagService;
        public AdminHomeController(ILogger<AdminHomeController> logger/*, ITagService tagService*/)
        {
            _logger = logger;
            //_tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
