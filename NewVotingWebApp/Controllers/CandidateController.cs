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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        //Added Dependency Injection for repository using constructor.
        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // This method will create candidate as well as also assign category to that candidate.
        [HttpPost]
        [Route("CreateCandidate")]
        public async Task<IActionResult> CreateCandidate([FromBody] Candidate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var candidateId = await _candidateRepository.CreateCandidate(model);
                    if (candidateId > 0)
                        return Ok("Candidate Added Successfully");

                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
