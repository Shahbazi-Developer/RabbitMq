using Book.Core.RequestResponse.Books.Commands.BookShop.Create;
using Book.Core.RequestResponse.Books.Commands.BookShop.Delete;
using Book.Core.RequestResponse.Books.Commands.BookShop.Update;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetById;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetList;
using Book.Core.RequestResponse.Books.Queries.BookShop.GetPageFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamin.Core.RequestResponse.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace Book.Endpoints.API.BookShops
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShopController : BaseController
    {

        #region Command

        [HttpPost("CreateBookShop")]
        public async Task<IActionResult> CreateBookShop([FromBody] CreateBookShopCommands command)
           => await Create<CreateBookShopCommands>(command);
        
        [HttpDelete("DeleteBookShop")]
        public async Task<IActionResult> DeleteBookShop([FromBody] DeleteBookShopCommands command)
            => await Delete(command);

        [HttpPut("UpdateBookShop")]
        public async Task<IActionResult> UpdateBookShop([FromBody] UpdateBookShopCommands command)
            => await Edit(command);

        #endregion



        #region Queries

        [HttpGet("GetBookShopById")]
        public async Task<IActionResult> GetBookShopById([FromQuery] GetBookShopByIdQuery query)
           => await Query<GetBookShopByIdQuery, GetBookShopByIdResult?>(query);
        

        [HttpGet("GetBookShopPageFilter")]
        public async Task<IActionResult> GetPageFilter([FromQuery] GetBookShopPageFilterQuery query)
            => await Query<GetBookShopPageFilterQuery, PagedData<GetBookShopPageFilterResult>>(query);
        

        [HttpGet("GetBookShopList")]
        public async Task<IActionResult> GetBookShopList([FromQuery] GetBookShopListQuery query)
            => await Query<GetBookShopListQuery, List<GetBookShopListResult>>(query);
        

        #endregion
    }
}
