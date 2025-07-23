using Book.SharedKernel.Translators;
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
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(DeleteBookShopCommands.Id)]);
        }
    }
}