using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Create;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Update;
using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace Book.Endpoints.API.BookShopCategorys
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookshopController : BaseController
    {
        [HttpPost("CreateBookShopCategory")]
        public Task<IActionResult> CreateBookShopCategory([FromBody] CreateBookShopCategoryCommand command)
        {
            return Create(command);
        }

        [HttpPut("UpdateBookShopCategory")]
        public async Task<IActionResult> UpdateBookShopCategory([FromBody] UpadateBookShopCategoryCommand command)
            => await Edit(command);
    }
}
