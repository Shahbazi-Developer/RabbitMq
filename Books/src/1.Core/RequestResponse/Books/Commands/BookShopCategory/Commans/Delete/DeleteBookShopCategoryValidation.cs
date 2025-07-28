using Book.SharedKernel.Translators;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.Commands.BookShopCategory.Commans.Delete
{
    public class DeleteBookShopCategoryValidation : AbstractValidator<DeleteBookShopCategoryCommand>
    {
        public DeleteBookShopCategoryValidation(ITranslator translator)
        {
            RuleFor(x => x.BookShopId)
               .NotEmpty()
              .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(DeleteBookShopCategoryCommand.BookShopId)]);

            RuleFor(x => x.Id)
              .NotEmpty()
             .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(DeleteBookShopCategoryCommand.Id)]);
        }
    }
}
