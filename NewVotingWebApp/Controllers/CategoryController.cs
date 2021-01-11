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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        
        //Added Dependency Injection for repository using constructor.
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // This method will create category if modelstate is valid.
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody]Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryId = await _categoryRepository.CreateCategory(model);
                    if (categoryId > 0)
                        return Ok("Category Added Successfully");

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

/*
Note: As per requirement, I have implemented only adding category. 
As updation and deleteion can not done with category so that methods are not added.
*/
