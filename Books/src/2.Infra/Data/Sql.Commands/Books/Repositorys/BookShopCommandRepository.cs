using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Core.Contracts.Books.Commands;
using Book.Core.Contracts.Books.DominService.ArticleGraphServices;
using Book.Core.Domain.Books.Entitie;
using Book.Infra.Data.Sql.Commands.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Commands;

namespace Book.Infra.Data.Sql.Commands.Books.Repositorys
{
    public class BookShopCommandRepository : BaseCommandRepository<BookShop, BookCommandDbContext, int>, IBookShopCommandRepository
    {
        public BookShopCommandRepository(BookCommandDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BookShop?> GetGraph(BookShopGraphModels model)
        {

            var article = _dbContext.Set<BookShop>().AsQueryable();

            if (model.BookShopId.HasValue)
            {
                article = article.Where(s => s.Id == model.BookShopId);
            }

            if (model.BookShopCategoryGraphModel is not null)
            {
                article = article.Include(x => x.BookShopCategory).Where(x => x.Id == model.BookShopCategoryGraphModel.BookShopId
                && x.BookShopCategory.Any(x => x.Id == model.BookShopCategoryGraphModel.BookShopCategoryId));
            }

            return await article.FirstOrDefaultAsync();
        }
        }
    }
