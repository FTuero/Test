using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Services
{
    public class NoteImpl : INoteService
    {

        private readonly ApplicationContext apContext;

        private IPersonService pService;

        private ITicketService tService; 

        public NoteImpl(ApplicationContext apContext, IPersonService pService, ITicketService tService)
        {
            this.apContext = apContext;
            this.pService = pService;
            this.tService = tService;
        }

        public void CreateNote(Note note)
        {
            apContext.Notes.Add(note);
            apContext.SaveChanges();
        }

        public Note GetNote(int id)
        {
            return apContext.Notes.Where(n => n.Id == id).FirstOrDefault();
        }

        public ICollection<Note> GetNotes()
        {
            return apContext.Notes.ToList();
        }


        public void UpdateNote(Note ntNew, Note ntOld)
        {

            ntOld.Description = ntNew.Description;
            ntOld.TicketId = ntNew.TicketId;

            apContext.Update(ntOld);
            apContext.SaveChanges();

        }
        public string RemoveNote(int idUser, int idTicket, Note note)
        {
            string message = String.Empty;

            if (IsYours(idUser, idTicket))
            {
                note.isPassive = true;
                apContext.SaveChanges();
                message = "Removed note.";
            }
            else
            {
                message = "You have not permissions."; 
            }

            return message; 
        }

        public string DeleteNote(int idUser, Note note)
        {
            string message = String.Empty;

            if (pService.GetPerson(idUser).IsAdmin)
            {
                apContext.Notes.Remove(note);
                apContext.SaveChanges();
                message = "Removed note.";
            }
            else
            {
                message = "You have not permissions.";
            }

            return message;
        }

        private bool IsYours(int idUser, int idTicket)
        {
            return tService.GetTicket(idTicket).PersonId.Equals(idUser);
        }
    }
}
