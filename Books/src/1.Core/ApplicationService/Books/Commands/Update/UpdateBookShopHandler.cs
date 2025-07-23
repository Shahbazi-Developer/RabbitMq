using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Contracts.Books.Commands;
using Book.Core.Domain.Books.Parameters;
using Book.Core.RequestResponse.Books.Commands.Update;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.Commands.Update
{
    public class UpdateBookShopHandler : CommandHandler<UpdateBookShopCommands>
    {
        private readonly IBookShopCommandRepository _commandRepository;

        public UpdateBookShopHandler(ZaminServices zaminServices ,IBookShopCommandRepository commandRepository)  : base(zaminServices) 
        {
            _commandRepository = commandRepository;
        }

        public override async Task<CommandResult> Handle(UpdateBookShopCommands command)
        {
            var entity = await _commandRepository.GetAsync(command.Id);

            if (entity is null)
            {
                throw new InvalidEntityStateException("VALIDATION_ERROR_NOT_EXIST", nameof(entity));
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
                                                    command.CreationDate);

            entity.Update(parameter);

            await _commandRepository.CommitAsync();

            return Ok();
        }
    }
}
