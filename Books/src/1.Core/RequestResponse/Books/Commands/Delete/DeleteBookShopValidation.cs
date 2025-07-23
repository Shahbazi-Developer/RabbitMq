using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.RequestResponse.Books.Commands.Create;
using Book.Core.Resources;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.Commands.Delete
{
    public class DeleteBookShopValidation : AbstractValidator<DeleteBookShopCommands>
    {
        public DeleteBookShopValidation(ITranslator translator)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
               .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(DeleteBookShopCommands.Id)]);
        }
    }
}