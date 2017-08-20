using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {
        IEnumerable<Page> GetByAlias(string alias);
    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Page> GetByAlias(string alias)
        {
            return this.DbContext.Pages.Where(x => x.Alias == alias);
        }
    }
}