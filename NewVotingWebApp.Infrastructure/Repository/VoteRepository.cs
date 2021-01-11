using Microsoft.EntityFrameworkCore;
using NewVotingWebApp.Core.Data;
using NewVotingWebApp.Core.Entities;
using NewVotingWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewVotingWebApp.Infrastructure.Repository
{
    class VoteRepository : IVoteRepository
    {
        private readonly AppDbContext _appDbContext;

        public VoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> SendVote(Vote vote)
        {
            var voteidnew = _appDbContext.Votes
                   .Where(v => v.VoterId == vote.VoterId && v.CategoryId == vote.CategoryId)
                   .FirstOrDefault();

            if (voteidnew != null)
            {
                return 0;

            }
            else
            {
                _appDbContext.Votes.Add(vote);
                var voteId = await _appDbContext.SaveChangesAsync();

                return voteId;
            }
        }

        public async Task<int> GetVoteCount(int? id)
        {
            var votecount = await _appDbContext.Votes
                .Where(c => c.CandidateId == id)
                .CountAsync();

            return votecount;
        }
    }
}
