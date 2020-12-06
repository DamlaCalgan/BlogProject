﻿using DamlaProje.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamlaProje.Blog.DTO.DTOs.CategoryDtos
{
    public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}