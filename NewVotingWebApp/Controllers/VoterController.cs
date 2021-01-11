using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewVotingWebApp.Core.Entities;
using NewVotingWebApp.Core.Repositories;

namespace NewVotingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterRepository _voterRepository;

        //Added Dependency Injection for repository using constructor.
        public VoterController(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        // This method will create voter user and also check if voter's age is > 18 or not.
        // If voter's age is not > 18, then we will display message.
        [HttpPost]
        [Route("CreateVoter")]
        public async Task<ActionResult<Voter>> CreateVoter([FromBody] Voter model)
        {
            if (ModelState.IsValid)
            {
                //First we get today's date.
                var today = DateTime.Today;

                //Now calculate age.
                var age = today.Year - model.DateOfBirth.Year;

                if (age > 18)
                {
                    try
                    {
                        var voterId = await _voterRepository.CreateVoter(model);
                        if(voterId > 0)
                        {
                            return Ok("Voter Added Successfully");
                        }

                        return NotFound();
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound("Voter's Age must be > 18.");
                }
            }
            return NotFound();

        }

        //This method will delete voter user based on id of that user.
        //means we need to pass user's id in argument and based on that id, this method will delete user.
        [HttpDelete]
        [Route("DeleteVoter/{id}")]
        public async Task<ActionResult<Voter>> DeleteVoter(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                await _voterRepository.DeleteVoter(id);
                return Ok("Voter User Deleted Successfully.");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Using this method we can change age of Voter user. Here we need to pass DOB and based on that age will be updated.
        //It will also check, if age is > 18 or not, if not then give message.
        [HttpPut]
        [Route("UpdateAge/{id}")]
        public async Task<ActionResult<Voter>> UpdateAge(int id, [FromBody] Voter model)
        {
            if (ModelState.IsValid)
            {
                //First we get today's date.
                var today = DateTime.Today;

                //Now calculate age.
                var age = today.Year - model.DateOfBirth.Year;

                if (age > 18)
                {
                    try
                    {
                        await _voterRepository.UpdateAge(id, model);
                        return Ok("Voter Updated Successfully.");

                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound("Voter's Age must be > 18.");
                }
            }
            return NotFound();
        }
    }
}
