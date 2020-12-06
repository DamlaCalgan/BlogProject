using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCommentRepository : EfGenericRepository<Comment>, ICommentDal
    {
        private readonly BlogContext _context;
        public EfCommentRepository(BlogContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
            List<Comment> result = new List<Comment>();
            await GetComments(blogId, parentId, result);
            return result;
        }

        private async  Task GetComments(int blogId, int? parentId, List<Comment> result)
        {
            var comments = await _context.Comments.Where(I => I.BlogId == blogId && I.ParentCommentId == parentId).OrderByDescending(I => I.PostedTime).ToListAsync();
            if (comments.Count > 0)
            {
                foreach (var comment in comments)
                {
                    if (comment.SubComments == null)
                        comment.SubComments = new List<Comment>();
                    await GetComments(comment.BlogId, comment.Id, comment.SubComments);
                    if (!result.Contains(comment))
                    {
                        result.Add(comment);

                    }
                }
            }
        }
    }
}
