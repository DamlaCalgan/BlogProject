using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Interfaces
{
    public interface ICommentService : IGenericService<Comment>
    {
        Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId);
    }
}
