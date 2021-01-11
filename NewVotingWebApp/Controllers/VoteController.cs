using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewVotingWebApp.Core.Entities;
using NewVotingWebApp.Core.Repositories;

namespace NewVotingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteRepository _voteRepository;

        //Added Dependency Injection for repository using constructor.
        public VoteController(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        // Using this method voter user can send vote to partiuclar candidate.
        [HttpPost]
        [Route("SendVote")]
        public async Task<ActionResult<int>> SendVote([FromBody] Vote model)
        {
            if (ModelState.IsValid)
            {
                var voteidnew = await _voteRepository.SendVote(model);

                if(voteidnew == 0)
                {
                    return NotFound("You have already given vote for this category, please give vote to another category");

                } else
                {
                    return Ok("You have successfully given vote. Thanks for that.");
                }
            }

            return NotFound();
        }

        //This method is to get number of votes for a candidate.
        //You need to pass candidate Id, and based on that it will return total number of votes.
        [HttpGet]
        [Route("GetVoteCount/{id}")]
        public async Task<ActionResult<Vote>> GetVoteCount(int? id)
        {
            var votecount = await _voteRepository.GetVoteCount(id);

            if(votecount != 0)
            {
                return Ok("For this candidate total vote is " + votecount);
            } else
            {
                return NotFound("For this candidate there is not any vote.");
            }
        }
    }
}
