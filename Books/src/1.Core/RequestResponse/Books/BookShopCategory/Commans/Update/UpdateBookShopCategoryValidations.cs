using Book.Core.Resources;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.BookShopCategory.Commans.Update
{
    public class UpdateBookShopCategoryValidations : AbstractValidator<UpadateBookShopCategoryCommand>
    {
        public UpdateBookShopCategoryValidations(ITranslator translator)
        {

            RuleFor(a => a.BookShopCategoryId)
                 .NotEmpty()
                 .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpadateBookShopCategoryCommand.BookShopCategoryId)]);

            RuleFor(a => a.BookShopId)
                 .NotEmpty()
                 .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpadateBookShopCategoryCommand.BookShopId)]);

            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_EMPTY, nameof(UpadateBookShopCategoryCommand.Title)]);
        }
    }
}
