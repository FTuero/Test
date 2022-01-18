using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Services
{
    public interface ITicketService
    {

        Ticket GetTicket(int id);

        ICollection<Ticket> GetTickets();

        void CreateTicket(Ticket t);

        void UpdateTicket(Ticket tNew, Ticket tOld);

        void RemoveTicket(Ticket t);


    }
}
