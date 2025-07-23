using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Resources;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.Commands.Create
{
    public class CreateBookShopValidation : AbstractValidator<CreateBookShopCommands>
    {
        public CreateBookShopValidation(ITranslator translator)
        {
            RuleFor(x => x.Title)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Title)]);
            RuleFor(x => x.Author)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Author)]);
            RuleFor(x => x.Publisher)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Publisher)]);
            RuleFor(x => x.ISBN)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.ISBN)]);
            RuleFor(x => x.Language)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Language)]);
            RuleFor(x => x.Genre)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Genre)]);
            RuleFor(x => x.PublicationYear)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.PublicationYear)]);
            RuleFor(x => x.Edition)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Edition)]);
            RuleFor(x => x.Price)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Price)]);
            RuleFor(x => x.IsAvailable)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.IsAvailable)]);
            RuleFor(x => x.StockQuantity)
              .NotEmpty()
               .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.StockQuantity)]);
            RuleFor(x => x.CreationDate)
                    .NotEmpty()
                    .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.CreationDate)]);

        }


    }
}
