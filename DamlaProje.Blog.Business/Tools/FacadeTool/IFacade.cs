﻿using DamlaProje.Blog.Business.Tools.LogTool;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamlaProje.Blog.Business.Tools.FacadeTool
{
    public interface IFacade
    {
        public IMemoryCache MemoryCache { get; set; }
        public ICustomLogger CustomLogger { get; set; }
    }
}
