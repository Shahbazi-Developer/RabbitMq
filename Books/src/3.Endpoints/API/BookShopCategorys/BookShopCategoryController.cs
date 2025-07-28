using Book.Core.RequestResponse.Books.Commands.BookShop.Delete;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Create;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Delete;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Update;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetList;
using Book.Core.RequestResponse.Books.Queries.BookShopCategory.GetList;
using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace Book.Endpoints.API.BookShopCategorys
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShopCategoryController : BaseController
    {

        #region Command

        [HttpPost("CreateBookShopCategory")]
        public async Task<IActionResult> CreateBookShopCategory([FromBody] CreateBookShopCategoryCommand command)
           => await Create(command);

        [HttpDelete("DeleteBookShopCategory")]
        public async Task<IActionResult> DeleteBookShopCategory([FromBody] DeleteBookShopCategoryCommand command)
           => await Delete(command);



        [HttpPut("UpdateBookShopCategory")]
        public async Task<IActionResult> UpdateBookShopCategory([FromBody] UpadateBookShopCategoryCommand command)
            => await Edit(command);

        #endregion


        #region Queries

        [HttpGet("GetBookShopCategoryList")]
        public async Task<IActionResult> GetBookShopCategoryList([FromQuery] GetBookShopCategoryListQuery query)
            => await Query<GetBookShopCategoryListQuery, List<GetBookShopCategoryListResult>>(query);

        #endregion
    }
}
