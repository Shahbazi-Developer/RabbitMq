using Book.Core.ApplicationService.Mappers;
using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices.Models;
using Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Delete;
using Book.SharedKernel.Translators;
using Microsoft.Extensions.Logging;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.bookShopCategorys.Commands.Delete
{
    public class DeleteBookShopCategoryHandler : CommandHandler<DeleteBookShopCategoryCommand>
    {
        private readonly IBookShopCommandRepository _bookShopCommandRepository;
        private readonly IBookShopGraphServeice _bookShopGraphServeice;
        private readonly ILogger<DeleteBookShopCategoryHandler> _logger;
        private readonly ITranslator _translator;

        public DeleteBookShopCategoryHandler(ZaminServices zaminServices,
                                             ITranslator translator,
                                             IBookShopCommandRepository bookShopCommandRepository,
                                             IBookShopGraphServeice bookShopGraphServeice,
                                             ILogger<DeleteBookShopCategoryHandler> logger) : base(zaminServices)
        {
            _translator = translator;
            _bookShopCommandRepository = bookShopCommandRepository;
            _bookShopGraphServeice = bookShopGraphServeice;
            _logger = logger;
        }

        public override async Task<CommandResult> Handle(DeleteBookShopCategoryCommand command)
        {
            var bookShopGraphModels = new BookShopGraphModels
            {
                IncludeBookShopCategoryModel = new IncludeBookShopCategoryModel
                {
                    Id = command.Id,
                    BookShopId = command.BookShopId

                }
            };

            var BookShopCategoryResult = await _bookShopGraphServeice.GetGraph(bookShopGraphModels);

            if (!BookShopCategoryResult.IsSuccess || BookShopCategoryResult.Result!.BookShopCategory.Count() == 0)
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.Id)]);
            }

            var bookShopCategory = BookShopCategoryResult.Result;

            bool bookShopCategoryDeleteProperty = bookShopCategory!.BookShopCategory
            .Select(x => new { x.Id, x.Deleted })
            .First(x => x.Id == command.Id).Deleted.Value;

            if (bookShopCategoryDeleteProperty)
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.Id));
            }


            var BoohSh = BookShopCategoryResult.Result;

            BoohSh.DeleteBookShopCategory(command.ToParameter());

            await _bookShopCommandRepository.CommitAsync();

            return Ok();
        }
    }
}
