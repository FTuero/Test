using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Services
{
    public class TicketImpl : ITicketService
    {

        private readonly ApplicationContext apContext;

        public TicketImpl(ApplicationContext apContext)
        {
            this.apContext = apContext;
        }

        public void CreateTicket(Ticket tNew)
        {
            apContext.Tickets.Add(tNew);
            apContext.SaveChanges();
        }

        public Ticket GetTicket(int id)
        {
            return apContext.Tickets.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<Ticket> GetTickets()
        {
            return apContext.Tickets.ToList();
        }

        public void UpdateTicket(Ticket tNew, Ticket tOld)
        {
            tOld.Content = tNew.Content;
            tOld.PersonId = tNew.PersonId;

            apContext.Update(tOld);
            apContext.SaveChanges();
        }

        public void RemoveTicket(Ticket ticket)
        {

            IList<Note> notes = FindNotebyTicket(ticket.Id);

            foreach(Note nt in notes)
            {
                apContext.Notes.Remove(nt);
                apContext.SaveChanges();
            }

            apContext.Tickets.Remove(ticket);
            apContext.SaveChanges();

        }


        private IList<Note> FindNotebyTicket(int idTicket)
        {
            return apContext.Notes.Where(n => n.TicketId == idTicket).ToList();
        } 

    }
}
