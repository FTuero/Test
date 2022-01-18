using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AareonTechnicalTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        private readonly INoteService nService;

        public NoteController(INoteService nService)
        {
            this.nService = nService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            return Ok(nService.GetNotes());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Note> Get(int id)
        {
            return Ok(nService.GetNote(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Note note)
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
                    nService.CreateNote(note);
                    resp = Ok("Created note.");
                }

            }
            catch (Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;
        }

        [HttpPut("{idNote}")]
        public ActionResult Put(int idNote, Note noteNew)
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
                    Note ntOld = nService.GetNote(idNote);

                    if (ntOld is null)
                    {
                        resp = BadRequest($"Note with {idNote} not found.");
                    }
                    else
                    {

                        nService.UpdateNote(noteNew, ntOld);
                        resp = Ok("Updated note.");
                    }

                }
            }catch(Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }



            return resp;
        }

        [HttpPut("~/api/user/{idUser}/ticket/{idTicket}/[controller]/{idNote}")]
        public ActionResult Remove(int idUser, int idTicket, int idNote)
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
                    Note ntOld = nService.GetNote(idNote);

                    if (ntOld is null)
                    {
                        resp = BadRequest($"Note with {idNote} not found.");
                    }
                    else
                    {
                        nService.RemoveNote(idUser, idTicket, ntOld);
                        resp = Ok("Updated note.");
                    }
                }
            }
            catch (Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;
        }


        [HttpDelete]
        [Route("~/api/admin/{idUser}/[controller]/{idNote}")]
        public ActionResult Delete(int idUser, int idNote)
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
                    Note ntRemoved = nService.GetNote(idNote);                

                    if (ntRemoved is null)
                    {
                        resp = BadRequest($"Note with {idNote} not found.");
                    }
                    else
                    {                    
                        resp = Ok(nService.DeleteNote(idUser, ntRemoved));
                    }
                }
            }
            catch (Exception ex)
            {
                resp = BadRequest("There was an error: " + ex.Message);
            }

            return resp;
        }
    }
}
