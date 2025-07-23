using Book.Core.Contracts.Books.Commands;
using Book.Core.Domain.Books.Entitie;
using Book.Core.Domain.Books.Parameters;
using Book.Core.RequestResponse.Books.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.Commands.Create
{
    public class CreateBookShopeHandler : CommandHandler<CreateBookShopCommands>
    {
        private readonly IBookShopCommandRepository _commandRepository;
        private readonly IRabbitMqProducer _rabbitMqProducer;

        public CreateBookShopeHandler(
            ZaminServices zaminServices,
            IBookShopCommandRepository commandRepository,
            IRabbitMqProducer rabbitMqProducer)
            : base(zaminServices)
        {
            _commandRepository = commandRepository;
            _rabbitMqProducer = rabbitMqProducer;
        }

        public override async Task<CommandResult> Handle(CreateBookShopCommands command)
        {
            var parameter = new CreateBookShopParameter(
                command.Title,
                command.Author,
                command.Publisher,
                command.ISBN,
                command.Language,
                command.Genre,
                command.PublicationYear,
                command.Edition,
                command.Price,
                command.IsAvailable,
                command.StockQuantity,
                command.CreationDate);

            var bookShop = new BookShop(parameter);
            await _commandRepository.InsertAsync(bookShop);
            await _commandRepository.CommitAsync();

            var message = new
            {
                BookId = bookShop.Id,
                Title = bookShop.Title,
                Author = bookShop.Author,
                CreationDate = bookShop.CreationDate,
                
            };

            await _rabbitMqProducer.SendMessageAsync(message);

            return await OkAsync();
        }

    }
}
