using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Contracts.Books.Commands;
using Book.Core.RequestResponse.Books.Commands.Delete;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Book.Core.ApplicationService.Books.Commands.Delete
{
    public class DeleteBookShopHandler : CommandHandler<DeleteBookShopCommands>
    {
        private readonly IBookShopCommandRepository _commandRepository;

        public DeleteBookShopHandler(ZaminServices zaminServices ,IBookShopCommandRepository commandRepository) : base(zaminServices) 
        {
            _commandRepository = commandRepository;
        }

        public override async Task<CommandResult> Handle(DeleteBookShopCommands command)
        {
            var entity = await _commandRepository.GetAsync(command.Id);
            if (entity is null)
            {
                throw new Exception("Not Found");
            }
            entity.BookShopDeleted();
            await _commandRepository.CommitAsync();
            return Ok();
        }
    }
}
