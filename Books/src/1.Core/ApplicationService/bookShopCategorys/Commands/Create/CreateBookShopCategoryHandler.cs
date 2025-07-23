using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Parameters;
using Book.Core.RequestResponse.Books.BookShopCategory.Commans.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.bookShopCategorys.Commands.Create
{
    public class CreateBookShopCategoryHandler : CommandHandler<CreateBookShopCategoryCommand>
    {
        private readonly IBookShopCommandRepository _commandRepository;
        private readonly IBookShopGraphServeice _bookShopGraphServeice;

        public CreateBookShopCategoryHandler(ZaminServices zaminServices, IBookShopGraphServeice bookShopGraphServeice, IBookShopCommandRepository commandRepository) : base(zaminServices) 
        {
            _bookShopGraphServeice = bookShopGraphServeice;
            _commandRepository = commandRepository;
        }

        public override async Task<CommandResult> Handle(CreateBookShopCategoryCommand command)
        {
            BookShopGraphModels bookShopGraphModels = new BookShopGraphModels
            {
                BookShopId = command.BookShopId,
            };
            var result = await _bookShopGraphServeice.GetGraph(bookShopGraphModels);
            if(!result.IsSuccess)
            {
                AddMessage("not Id");
                return Result(ApplicationServiceStatus.ValidationError);
            }
            var bookShop = result.Result;
            CreateBookShopCategoryParameter parameter = new(command.Title, command.Authors);
            bookShop.CreateBookShopCategory(parameter);
            await _commandRepository.CommitAsync();
            return Ok();
        }
    }
}


