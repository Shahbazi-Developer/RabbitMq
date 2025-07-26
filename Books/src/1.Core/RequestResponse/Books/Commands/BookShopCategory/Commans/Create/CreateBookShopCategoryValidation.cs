using Book.SharedKernel.Translators;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Create
{
    public class CreateBookShopCategoryValidation : AbstractValidator<CreateBookShopCategoryCommand>
    {
        public CreateBookShopCategoryValidation(ITranslator translator)
        {
            RuleFor(a => a.BookShopId)
                 .NotEmpty()
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCategoryCommand.BookShopId)]);

            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCategoryCommand.Title)]);
        }
    }
}
