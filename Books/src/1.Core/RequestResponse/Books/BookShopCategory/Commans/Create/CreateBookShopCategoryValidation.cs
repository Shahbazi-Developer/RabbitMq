using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Resources;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.BookShopCategory.Commans.Create
{
    public class CreateBookShopCategoryValidation : AbstractValidator<CreateBookShopCategoryCommand>
    {
        public CreateBookShopCategoryValidation(ITranslator translator)
        {
            RuleFor(a => a.BookShopId)
                 .NotEmpty()
                 .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCategoryCommand.BookShopId)]);

            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCategoryCommand.Title)]);
        }
    }
}
