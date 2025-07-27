using Book.Core.Contracts.Books.Commands;
using Book.Core.Domain.Books.Parameters.BookShop.Update;
using Book.Core.RequestResponse.Books.Commands.Update;
using Book.SharedKernel.Translators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.Commands.Update
{
    public class UpdateBookShopHandler : CommandHandler<UpdateBookShopCommands>
    {
        private readonly IBookShopCommandRepository _commandRepository;
        private readonly ITranslator _translator;
        private readonly ILogger<UpdateBookShopHandler> _logger;

        public UpdateBookShopHandler(ZaminServices zaminServices,
                                     IBookShopCommandRepository commandRepository,
                                     ITranslator translator,
                                     ILogger<UpdateBookShopHandler> logger) : base(zaminServices)
        {
            _commandRepository = commandRepository;
            _translator = translator;
            _logger = logger;
        }

        public override async Task<CommandResult> Handle(UpdateBookShopCommands command)
        {
            var entity = await _commandRepository.GetAsync(command.Id);

            if (entity is null)
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.Id)]);
            }
            UpdateBookShopParameter parameter = new(command.Title,
                                                    command.Publisher,
                                                    command.Author,
                                                    command.ISBN,
                                                    command.Language,
                                                    command.Genre,
                                                    command.PublicationYear,
                                                    command.Edition,
                                                    command.Price,
                                                    command.IsAvailable,
                                                    command.StockQuantity,
                                                    command.CreationDate,
                                                    command.Description);

            entity.Update(parameter);

            await _commandRepository.CommitAsync();

            return Ok();
        }
    }
}
