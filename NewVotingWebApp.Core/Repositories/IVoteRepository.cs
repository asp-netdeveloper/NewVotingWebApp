using NewVotingWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewVotingWebApp.Core.Repositories
{
    public interface IVoteRepository
    {
        Task<int> SendVote(Vote vote);

        Task<int> GetVoteCount(int? id);
    }
}
