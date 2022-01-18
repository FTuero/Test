using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;
using Audit.WebApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AareonTechnicalTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[AuditApi (IncludeHeaders = true, IncludeResponseHeaders = true, IncludeRequestBody = true, IncludeResponseBody = true)]
    public class TicketController : ControllerBase
    {

        private readonly ITicketService tService; 

        public TicketController(ITicketService tService)
        {
            this.tService = tService; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> Get()
        {
            return Ok(tService.GetTickets());
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> Get(int id)
        {
            return Ok(tService.GetTicket(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ticket ticket)
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
                    tService.CreateTicket(ticket);
                    resp = Ok("Created ticket.");
                }
            }
            catch (Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ticket tNew)
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
                    Ticket tOld = tService.GetTicket(id);

                    if (tOld is null)
                    {
                        resp = BadRequest($"Ticket with {id} not found.");
                    }
                    else
                    {
                        tService.UpdateTicket(tNew, tOld);
                        resp = Ok("Updated ticket.");
                    }

                }
            }            
            catch (Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }



            return resp;
        }

        [HttpDelete("{idTicket}")]
        public ActionResult Delete(int idTicket)
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
                    Ticket tkRemoved = tService.GetTicket(idTicket);

                    if (tkRemoved is null)
                    {
                        resp = BadRequest($"Ticket with {idTicket} not found.");
                    }
                    else
                    {
                        tService.RemoveTicket(tkRemoved);
                        resp = Ok("Removed ticket.");
                    }
                }
            }
            catch(Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;

        }
    }
}
