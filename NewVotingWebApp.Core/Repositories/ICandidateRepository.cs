using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewVotingWebApp.Core.Entities;

namespace NewVotingWebApp.Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<int> CreateCandidate(Candidate candiate);
    }
}
