using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FinalProject.ContextDBConfig;

namespace FinalProject.Controllers
{
    //Controller handling actions related to our Menu & Recipes 
    public class RecipeController : Controller
    {
        //Takes User Manager for managing users and DB connection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FinalProjectDBContext context;
        public RecipeController(UserManager<ApplicationUser> userManager, FinalProjectDBContext dBContext)
        {
            _userManager = userManager;
            context = dBContext;
        }

        //Returns the Menu&Recipe default view,and retrives TempData message that displayes the conf message after placing order
        public IActionResult Index()
        {
            ViewBag.OrderConfirmationMessage = TempData["OrderConfirmationMessage"] as string;
            return View();
        }

        //Returns the view with list of recipes passed as object in request body
        [HttpPost]
        public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        {
            return PartialView("_RecipeCard", recipes);
        }

        //Displays the view with a search query for recipes
        public IActionResult Search([FromQuery] string recipe)
        {
            ViewBag.Recipe = recipe;
            return View();
        }

        //Sets the ViewBag.Id with the id of clicked item,and returns the view for placing order/seeing recipe
        public IActionResult Order([FromQuery] string id)
        {
            ViewBag.Id = id;
            return View();
        }

        //Handles the showing of the Details Page with Order and Recipe Details for item, generates a random price for that item, and displays the order details using a partial view (`_ShowOrder`). The order details are stored in TempData to show a confirmation message.
        [HttpPost]
        public async Task<IActionResult> ShowOrder(OrderRecipeDetails orderRecipeDetails)
        {
            Random random = new Random();
            ViewBag.Price = random.Next(3, 15);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.UserId = user?.Id;
            ViewBag.Address = user?.Address;

            TempData["OrderConfirmationMessage"] = "Thank you for your purchase! Order is being processed...";

            return PartialView("_ShowOrder", orderRecipeDetails);
        }

        //Handles actual order submission and adds it to DB and redirect to the Index action whih takes to Home Page 
        [HttpPost]
        [Authorize]
        public IActionResult Order([FromForm] Order order)
        {
            order.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index", "Recipe");
            }
            return RedirectToAction("Order", "Recipe", new { id = order.Id });
        }
    }
}

