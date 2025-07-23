using Book.Core.Contracts.Books;
using Microsoft.Extensions.Logging;

namespace Book.Core.ApplicationService.Books.Commands.ReqBooks
{
    public class InventoryCheckResponseHandler
    {
        private readonly ILogger<InventoryCheckResponseHandler> _logger;

        public InventoryCheckResponseHandler(ILogger<InventoryCheckResponseHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(WarehouseMobileCreatedEvent response)
        {
            if (string.IsNullOrWhiteSpace(response.Title) || string.IsNullOrWhiteSpace(response.Author))
            {
                _logger.LogWarning("❌ پاسخ دریافتی از انبار نامعتبر است: عنوان یا نویسنده خالی است.");
            }
            else
            {
                _logger.LogInformation("📦 کتاب در انبار ثبت شد: '{Title}' از {Author} - تاریخ: {Date}",
                    response.Title, response.Author, response.CreationDate.ToString("yyyy/MM/dd HH:mm"));
            }

            // اگر نیاز به پردازش بیشتر دارید (مثل ذخیره در DB یا ارسال به SignalR)، اینجا انجام بده

            await Task.CompletedTask;
        }
    }
}
