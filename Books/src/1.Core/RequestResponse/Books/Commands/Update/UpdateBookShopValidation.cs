using Book.Core.RequestResponse.Books.Commands.Create;
using Book.SharedKernel.Translators;
using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace Book.Core.RequestResponse.Books.Commands.Update
{
    public class UpdateBookShopValidation : AbstractValidator<UpdateBookShopCommands>
    {
        public UpdateBookShopValidation(ITranslator translator)
        {

            RuleFor(x => x.Id)
                 .NotEmpty()
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(UpdateBookShopCommands.Id)]);


            RuleFor(x => x.Title)
                 .NotEmpty()
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Title)])
                 .MaximumLength(MaxLengthConfiguration.TITEL_MAXLENGTHS)
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(CreateBookShopCommands.Title),
                                         MaxLengthConfiguration.TITEL_MAXLENGTHS.ToString()])
                 .MinimumLength(MaxLengthConfiguration.TITEL_MINLENGTHS)
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MIN_LENGTH, nameof(CreateBookShopCommands.Title)
                                        , MaxLengthConfiguration.TITEL_MINLENGTHS.ToString()]);


            RuleFor(x => x.Author)
                 .NotEmpty()
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Author)])
                 .MaximumLength(MaxLengthConfiguration.AUTHOR_MAXLENGTHS)
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(CreateBookShopCommands.Author),
                                       MaxLengthConfiguration.TITEL_MAXLENGTHS.ToString()])
                 .MinimumLength(MaxLengthConfiguration.AUTHOR_MINLENGTHS)
                 .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MIN_LENGTH, nameof(CreateBookShopCommands.Author)
                                       , MaxLengthConfiguration.AUTHOR_MINLENGTHS.ToString()]);


            RuleFor(x => x.Publisher)
               .NotEmpty()
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Publisher)])
               .MaximumLength(MaxLengthConfiguration.ADDRESS_MAXLENGTHS)
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(CreateBookShopCommands.Publisher)]);


            RuleFor(x => x.ISBN)
                .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.ISBN)]);


            RuleFor(x => x.Language)
                .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Language)])
                .MaximumLength(MaxLengthConfiguration.LANGUAGE_MAXLENGTHS)
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(CreateBookShopCommands.Language)]);



            RuleFor(x => x.Genre)
               .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Genre)])
                .MaximumLength(MaxLengthConfiguration.GENRE_MAXLENGTHS)
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_MAX_LENGTH, nameof(CreateBookShopCommands.Genre)]);


            RuleFor(x => x.PublicationYear)
               .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.PublicationYear)]);


            RuleFor(x => x.Edition)
               .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Edition)]);


            RuleFor(x => x.Price)
               .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.Price)]);


            RuleFor(x => x.IsAvailable)
               .NotEmpty()
                .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.IsAvailable)]);


            RuleFor(x => x.StockQuantity)
              .NotEmpty()
               .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.StockQuantity)]);


            RuleFor(x => x.CreationDate)
                    .NotEmpty()
                    .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_EMPTY, nameof(CreateBookShopCommands.CreationDate)]);

        }


    }
}
