using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Services
{
    public interface IPersonService
    {

        Person GetPerson(int id);

        ICollection<Person> GetPersons();

        void CreatePerson(Person t);

        void UpdatePerson(Person tNew, Person tOld);

    }
}
