using BCommerce.Application.Services;
using BCommerce.Web.Helpers;
using BCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CheckoutService checkoutService;
        private readonly UserService userService;
        private readonly ApplicationUserContext applicationUserContext;

        public CheckoutController(CheckoutService checkoutService, ApplicationUserContext applicationUserContext, UserService userService)
        {
            this.checkoutService = checkoutService;
            this.applicationUserContext = applicationUserContext;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {


            if (applicationUserContext.UserId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var basketData = userService.GetUserBasket(applicationUserContext.UserId, null);

            ViewBag.BasketData = basketData.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pay(CheckoutModel model)
        {
            var result = await checkoutService.CreateOrder(applicationUserContext.UserId, new Core.DTO.CheckOutDTO
            {
                CCNumber = model.CCNumber,
                City = model.City,
                Country = model.Country,
                Cvv = model.Cvv,
                Description = model.Description,
                LastDate = Convert.ToInt32(model.LastDate.Replace("/", "")),
                Name = model.Name,
                PostCode = model.PostCode,
                Street = model.Street

            });

            return Json(result);


        }

        public async Task<IActionResult> Success(int id)
        {
            ViewBag.orderid = id;
            return View();
        }
    }
}
