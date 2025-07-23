using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Domain.Books.Entitie;
using Book.Core.Domain.Common.DomainBusiness;
using Zamin.Extensions.DependencyInjection.Abstractions;

namespace Book.Core.Contracts.Books.DominService.ArticleGraphServices
{
    public interface IBookShopGraphServeice : IScopeLifetime
    {
        Task<DomainBusinessResult<BookShop>> GetGraph(BookShopGraphModels model);


    }
}
