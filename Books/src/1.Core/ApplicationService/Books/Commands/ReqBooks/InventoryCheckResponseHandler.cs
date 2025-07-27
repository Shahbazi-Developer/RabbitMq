using Book.Core.Contracts.Books.Events;
using Book.SharedKernel.Translators;
using Microsoft.Extensions.Logging;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.ApplicationService.Books.Commands.ReqBooks
{
    public class InventoryCheckResponseHandler
    {
        private readonly ILogger<InventoryCheckResponseHandler> _logger;
        private readonly ITranslator _translator;

        public InventoryCheckResponseHandler(ILogger<InventoryCheckResponseHandler> logger, ITranslator translator)
        {
            _logger = logger;
            _translator = translator;
        }

        public async Task Handle(WarehouseMobileCreatedEvent response)
        {
            if (string.IsNullOrWhiteSpace(response.Title) || string.IsNullOrWhiteSpace(response.Author))
            {
                _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name]);
            }
            else
            {
               _logger.Log(LogLevel.Information, _translator[TranslatorKeys.HANDLER_RUN_LOG, GetType().Name],
                    response.Title, response.Author, response.CreationDate.ToString("yyyy/MM/dd HH:mm"));
            }

            await Task.CompletedTask;
        }
    }
}
