using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService pService; 

        public PersonController(IPersonService perService)
        {
            this.pService = perService; 
        }


        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(pService.GetPersons());
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return Ok(pService.GetPerson(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            ActionResult resp;
            
            try
            {

                if (!ModelState.IsValid)
                {
                    resp = BadRequest("Error data.");
                }
                else
                {
                    pService.CreatePerson(person);
                    resp = Ok("Created person.");
                }

            }
            catch (Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Person per)
        {
            
            ActionResult resp;

            try
            {
                if (!ModelState.IsValid)
                {
                    resp = BadRequest("Error data.");
                }
                else
                {
                    Person perOld = pService.GetPerson(id);

                    if (perOld is null) 
                    {
                        resp = BadRequest($"Person with {id} not found.");
                    } 
                    else
                    {
                        pService.UpdatePerson(per, perOld);
                        resp = Ok("Updated person.");
                    }

                }

            }
            catch(Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;
        }

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{

        //    ActionResult resp;

        //    if (!ModelState.IsValid)
        //    {
        //        resp = BadRequest("Error data.");
        //    }
        //    else
        //    {
        //        Person perRemoved = apContext.Persons.Where(p => p.Id == id).FirstOrDefault();

        //        if (perRemoved is null)
        //        {
        //            resp = BadRequest($"Person with {id} not found.");
        //        }
        //        else
        //        { 
        //            apContext.Persons.Remove(perRemoved);
        //            apContext.SaveChanges();
        //            resp = Ok("Removed person.");
        //        }

        //    }

        //    return resp;
        //}

    }
}
