using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetByAlias(string alias);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetByAlias(string alias)
        {
            return this.DbContext.Posts.Where(x => x.Alias == alias);
        }
    }
}