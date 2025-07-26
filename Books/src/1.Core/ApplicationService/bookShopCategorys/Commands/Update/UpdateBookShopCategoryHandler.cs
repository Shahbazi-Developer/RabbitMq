using Book.Core.ApplicationService.Books.DominService.BookShopGraphSrvice;
using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Parameters;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Update;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Update;
using Book.SharedKernel.Translators;
using Microsoft.Extensions.Logging;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.bookShopCategorys.Commands.Update
{
    public class UpdateBookShopCategoryHandler : CommandHandler<UpadateBookShopCategoryCommand>
    {
        private readonly IBookShopCommandRepository _bookShopCommandRepository;
        private readonly IBookShopGraphServeice _bookShopGraphServeice;
        private readonly ITranslator _translator;
        private readonly ILogger<UpdateBookShopCategoryHandler> _logger;

        public UpdateBookShopCategoryHandler(ZaminServices zaminServices, IBookShopCommandRepository bookShopCommandRepository, IBookShopGraphServeice bookShopGraphServeice, ITranslator translator, ILogger<UpdateBookShopCategoryHandler> logger) : base(zaminServices)
        {
            _bookShopCommandRepository = bookShopCommandRepository;
            _bookShopGraphServeice = bookShopGraphServeice;
            _translator = translator;
            _logger = logger;
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
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.BookShopId)]);
            }

            var articleCategory = entity.Result;

            var parameter = new UpdateBookShopCategoryParameter(command.BookShopCategoryId,
                                                                command.Title,
                                                                command.Authors);

            articleCategory!.UpdateBookShopCategory(parameter);

            await _bookShopCommandRepository.CommitAsync();

            return Ok();
        }
    }
}
