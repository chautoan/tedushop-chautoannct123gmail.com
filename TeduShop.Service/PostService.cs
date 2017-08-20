using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postReposiory;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postReposiory = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Post post)
        {
            _postReposiory.Add(post);
        }

        public void Delete(int id)
        {
            _postReposiory.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postReposiory.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postReposiory.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Select all post by tag
            return _postReposiory.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postReposiory.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postReposiory.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Comit();
        }

        public void Update(Post post)
        {
            _postReposiory.Update(post);
        }
    }
}
