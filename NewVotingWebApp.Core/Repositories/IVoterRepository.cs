using NewVotingWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewVotingWebApp.Core.Repositories
{
    public interface IVoterRepository
    {
        Task<int> CreateVoter(Voter voter);

        Task<int> DeleteVoter(int? id);

        Task<Voter> UpdateAge(int id, Voter voter);
    }
}
