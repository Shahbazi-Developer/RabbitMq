using Book.Core.Contracts.Books.Commands;
using Book.Core.RequestResponse.Books.Commands.BookShop.Delete;
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

namespace Book.Core.ApplicationService.Books.Commands.Delete
{
    public class DeleteBookShopHandler : CommandHandler<DeleteBookShopCommands>
    {
        private readonly IBookShopCommandRepository _commandRepository;
        private readonly ITranslator _translator;
        private readonly ILogger<DeleteBookShopHandler> _logger;

        public DeleteBookShopHandler(ZaminServices zaminServices, IBookShopCommandRepository commandRepository, ITranslator translator, ILogger<DeleteBookShopHandler> logger) : base(zaminServices)
        {
            _commandRepository = commandRepository;
            _translator = translator;
            _logger = logger;
        }

        public override async Task<CommandResult> Handle(DeleteBookShopCommands command)
        {
            var entity = await _commandRepository.GetAsync(command.Id);
            if (entity is null)
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);

                throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(command.Id)]);
            }

            entity.BookShopDeleted();
            await _commandRepository.CommitAsync();
            return Ok();
        }
    }
}
