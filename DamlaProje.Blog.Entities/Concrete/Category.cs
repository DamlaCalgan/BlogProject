using DamlaProje.Blog.Entities.Interfaces;
using System.Collections.Generic;

namespace DamlaProje.Blog.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
