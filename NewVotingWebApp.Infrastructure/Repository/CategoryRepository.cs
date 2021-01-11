using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewVotingWebApp.Core.Data;
using NewVotingWebApp.Core.Entities;
using NewVotingWebApp.Core.Repositories;

namespace NewVotingWebApp.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateCategory(Category category)
        {
                _appDbContext.Categories.Add(category);
                return await _appDbContext.SaveChangesAsync();
        }
    }
}
