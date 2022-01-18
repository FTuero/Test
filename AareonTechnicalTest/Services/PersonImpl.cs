using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Services
{
    public class PersonImpl : IPersonService
    {
        private readonly ApplicationContext apContext;

        public PersonImpl(ApplicationContext apContext)
        {
            this.apContext = apContext;
        }


        public ICollection<Person> GetPersons()
        {
            return apContext.Persons.ToList();
        }

        public Person GetPerson(int id)
        {
            return apContext.Persons.Where(p => p.Id == id).FirstOrDefault();
        }

        public void CreatePerson(Person p)
        {
            apContext.Persons.Add(p);
            apContext.SaveChanges();
        }

        public void UpdatePerson(Person tNew, Person tOld)
        {
            tOld.Forename = tNew.Forename;
            tOld.Surname = tNew.Surname;

            apContext.Update(tOld);
            apContext.SaveChanges();
        }
    }
}
