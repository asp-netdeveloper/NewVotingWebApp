using NewVotingWebApp.Core.Data;
using NewVotingWebApp.Core.Entities;
using NewVotingWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewVotingWebApp.Infrastructure.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _appDbContext;
        public CandidateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateCandidate(Candidate candidate)
        {
            _appDbContext.Candidates.Add(candidate);
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
