using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Services
{
    public interface INoteService
    {

        Note GetNote(int id);

        ICollection<Note> GetNotes();

        void CreateNote(Note note);

        void UpdateNote(Note ntNew, Note ntOld);

        string RemoveNote(int idUser, int idTicket, Note note);

        string DeleteNote(int idUser, Note note);
    }
}
