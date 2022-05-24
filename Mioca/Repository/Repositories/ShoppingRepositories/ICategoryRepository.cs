﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.ShoppingRepositories
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}
