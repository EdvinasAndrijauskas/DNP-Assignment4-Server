using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3.Persistance;
using Managing_Adults.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultService adultService;

        public AdultsController(IAdultService adultService)
        {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultService.GetAdultAsync();
                return Ok(adults);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddTodo([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await adultService.AddAdult(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteTodo([FromRoute] int id)
        {
            try
            {
                await adultService.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}