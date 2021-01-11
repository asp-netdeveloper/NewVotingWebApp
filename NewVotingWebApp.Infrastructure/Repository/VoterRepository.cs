using NewVotingWebApp.Core.Data;
using NewVotingWebApp.Core.Entities;
using NewVotingWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NewVotingWebApp.Infrastructure.Repository
{
    public class VoterRepository : IVoterRepository
    {
        private readonly AppDbContext _appDbContext;

        public VoterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateVoter(Voter voter)
        {
            _appDbContext.Voters.Add(voter);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteVoter(int? id)
        {
            int result = 0;

            var voter = await _appDbContext.Voters.FirstOrDefaultAsync(v => v.VoterId == id);

            if(voter != null)
            {
                _appDbContext.Voters.Remove(voter);
                result = _appDbContext.SaveChanges();
            }

            return result;
        }

        public async Task<Voter> UpdateAge(int id, Voter voter)
        {
            var voterdetail = await _appDbContext.Voters.FirstOrDefaultAsync(v => v.VoterId == id);
            
            voterdetail.DateOfBirth = voter.DateOfBirth;
            await _appDbContext.SaveChangesAsync();

            return voterdetail;

        }
    }
}
