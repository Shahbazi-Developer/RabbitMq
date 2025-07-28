using Book.Core.ApplicationService.Mappers;
using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Parameters.BookShopCategory.Create;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Create;
using Book.SharedKernel.Translators;
using Microsoft.Extensions.Logging;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.bookShopCategorys.Commands.Create
{
    public class CreateBookShopCategoryHandler : CommandHandler<CreateBookShopCategoryCommand>
    {
        private readonly IBookShopCommandRepository _commandRepository;
        private readonly IBookShopGraphServeice _bookShopGraphServeice;
        private readonly ITranslator _translator;
        private readonly ILogger<CreateBookShopCategoryHandler> _logger;

        public CreateBookShopCategoryHandler(ZaminServices zaminServices,
                                             IBookShopCommandRepository commandRepository,
                                             IBookShopGraphServeice bookShopGraphServeice,
                                             ITranslator translator,
                                             ILogger<CreateBookShopCategoryHandler> logger) : base(zaminServices)
        {

            _commandRepository = commandRepository;
            _bookShopGraphServeice = bookShopGraphServeice;
            _translator = translator;
            _logger = logger;
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
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.BookShopId)]);
            }

            var bookShop = result.Result;

            bookShop.CreateBookShopCategory(command.ToParameter());

            await _commandRepository.CommitAsync();

            return Ok();
        }
    }
}


