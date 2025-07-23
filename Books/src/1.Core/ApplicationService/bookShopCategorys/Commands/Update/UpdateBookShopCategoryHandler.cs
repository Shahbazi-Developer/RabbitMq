using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Parameters;
using Book.Core.RequestResponse.Books.BookShopCategory.Commans.Update;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.bookShopCategorys.Commands.Update
{
    public class UpdateBookShopCategoryHandler : CommandHandler<UpadateBookShopCategoryCommand>
    {
        private readonly IBookShopCommandRepository _bookShopCommandRepository;
        private readonly IBookShopGraphServeice _bookShopGraphServeice;

        public UpdateBookShopCategoryHandler (ZaminServices zaminServices, IBookShopGraphServeice bookShopGraphServeice, IBookShopCommandRepository bookShopCommandRepository) : base (zaminServices)
        {
            _bookShopGraphServeice = bookShopGraphServeice;
            _bookShopCommandRepository = bookShopCommandRepository;
        }

        public override async Task<CommandResult> Handle(UpadateBookShopCategoryCommand command)
        {
            BookShopGraphModels bookShopGraphModels = new BookShopGraphModels
            {
                BookShopCategoryGraphModel = new()
                {
                    BookShopId = command.BookShopId,
                    BookShopCategoryId = command.BookShopCategoryId
                }
            };

            var entity = await _bookShopGraphServeice.GetGraph(bookShopGraphModels);

            if (!entity.IsSuccess)
            {
                throw new InvalidEntityStateException("VALIDATION_ERROR_NOT_EXIST", nameof(entity));
            }

            var articleCategory = entity.Result;

            var parameter = new UpdateBookShopCategoryParameter(command.BookShopCategoryId, command.Title, command.Authors);

            articleCategory!.UpdateBookShopCategory(parameter);

            await _bookShopCommandRepository.CommitAsync();

            return Ok();
        }
    }
}
