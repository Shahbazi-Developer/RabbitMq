using Book.Core.RequestResponse.Books.Commands.Create;
using Book.Core.RequestResponse.Books.Commands.Delete;
using Book.Core.RequestResponse.Books.Commands.Update;
using Book.Core.RequestResponse.Books.Queries.GetById;
using Book.Core.RequestResponse.Books.Queries.GetList;
using Book.Core.RequestResponse.Books.Queries.GetPageFilter;
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateBookShopCommands command)
        {
            return await Create<CreateBookShopCommands>(command);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMobile([FromBody] UpdateBookShopCommands command)
            => await Edit(command);

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMobile([FromBody] DeleteBookShopCommands command)
            => await Delete(command);


        #region Queries
        [HttpGet("GetBookShopById")]
        public Task<IActionResult> GetBookShopById([FromQuery] GetBookShopByIdQuery query)
        {
            return Query<GetBookShopByIdQuery, GetBookShopByIdResult?>(query);
        }

        [HttpGet("GetBookShopPageFilter")]
        public async Task<IActionResult> GetPageFilter([FromQuery] GetBookShopPageFilterQuery query)
        {
            return await Query<GetBookShopPageFilterQuery, PagedData<GetBookShopPageFilterResult>>(query);
        }

        [HttpGet("GetBookShopList")]
        public Task<IActionResult> GetBookShopList([FromQuery] GetBookShopListQuery query)
        {
            return Query<GetBookShopListQuery, List<GetBookShopListResult>>(query);
        }

        #endregion
    }
}
