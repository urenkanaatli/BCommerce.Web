using BCommerce.Application.Services.AfterRepoAndUOWService;
using BCommerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService commentService;
        private readonly ApplicationUserContext applicationUserContext;
        public CommentController(CommentService commentService, ApplicationUserContext applicationUserContext)
        {
            this.commentService = commentService;
            this.applicationUserContext = applicationUserContext;

        }
        public IActionResult Send(int productid, string messeage)
        {

            var result = commentService.SendCommant(applicationUserContext.UserId, messeage, productid);
            return Json(result);
        }
    }
}
