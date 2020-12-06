using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.DataAccess.Interfaces
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId,int? parentId);
    }
}
