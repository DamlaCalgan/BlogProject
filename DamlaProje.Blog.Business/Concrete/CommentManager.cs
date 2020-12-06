using DamlaProje.Blog.Business.Interfaces;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        
        private readonly ICommentDal _commentDal;
        public CommentManager(IGenericDal<Comment> genericDal, ICommentDal commentDal) : base(genericDal)
        {
            
            _commentDal = commentDal;
        }

        public Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
            return _commentDal.GetAllWithSubCommentsAsync(blogId,parentId);
        }
    }
}
