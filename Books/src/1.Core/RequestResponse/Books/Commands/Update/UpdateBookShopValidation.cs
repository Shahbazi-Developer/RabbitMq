using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.RequestResponse.Books.Commands.Create;
using Book.Core.RequestResponse.Books.Commands.Delete;
using Book.Core.Resources;
using FluentValidation;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.Commands.Update
{
    public class UpdateBookShopValidation : AbstractValidator<UpdateBookShopCommands>
    {
        public UpdateBookShopValidation(ITranslator translator)
        {

            RuleFor(x => x.Id)
               .NotEmpty()
              .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Id)]);
            RuleFor(x => x.Title)
              .NotEmpty()
               .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Title)]);
            RuleFor(x => x.Author)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Author)]);
            RuleFor(x => x.Publisher)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Publisher)]);
            RuleFor(x => x.ISBN)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.ISBN)]);
            RuleFor(x => x.Language)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Language)]);
            RuleFor(x => x.Genre)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Genre)]);
            RuleFor(x => x.PublicationYear)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.PublicationYear)]);
            RuleFor(x => x.Edition)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Edition)]);
            RuleFor(x => x.Price)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Price)]);
            RuleFor(x => x.IsAvailable)
               .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.IsAvailable)]);
            RuleFor(x => x.StockQuantity)
              .NotEmpty()
               .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.StockQuantity)]);

        }


    }
}
