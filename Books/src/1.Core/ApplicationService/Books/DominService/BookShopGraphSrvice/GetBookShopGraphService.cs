using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Entitie;
using Book.Core.Domain.Common.DomainBusiness;
using Zamin.Utilities.Resources.Translators;

namespace Book.Core.ApplicationService.Books.DominService.BookShopGraphSrvice
{
    public class GetBookShopGraphService : IBookShopGraphServeice
    {
        private readonly IBookShopCommandRepository _commandRepository;

        public GetBookShopGraphService(IBookShopCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public async Task<DomainBusinessResult<BookShop>> GetGraph(BookShopGraphModels model)
        {
            DomainBusinessResult<BookShop> result = new();
            var bookShop = await _commandRepository.GetGraph(model);
            if (bookShop is null)
            {
                result.AddError(TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, nameof(bookShop));
                return result;
            }
            result.Result = bookShop;
            return result;

        }
    }
}
