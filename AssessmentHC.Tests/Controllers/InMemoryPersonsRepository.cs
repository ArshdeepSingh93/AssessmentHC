using AssessmentHC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentHC.Tests.Controllers
{
    internal class InMemoryPersonsRepository :IPersonRepository
    {
        private List<Person> _db = new List<Person>();

        public Exception ExceptionToThrow { get; set; }
        //public List<Contact> Items { get; set; }

        public void SaveChanges(Person personToUpdate)
        {

            foreach (Person p in _db)
            {
                if (p.Id == personToUpdate.Id)
                {
                    _db.Remove(p);
                    _db.Add(personToUpdate);
                    break;
                }
            }
        }

        public void Add(Person personToAdd)
        {
            _db.Add(personToAdd);
        }

        public Person GetPersonByID(int id)
        {
            return _db.FirstOrDefault(d => d.Id == id);
        }

        public void CreateNewPerson(Person personToCreate)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(personToCreate);
            
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _db.ToList();
        }
        public IEnumerable<Person> GetAllPersonsByName(string searchText)
        {
            return _db.Where(x => x.FName.ToLower().Contains(searchText.ToLower()) || x.LName.ToLower().Contains(searchText.ToLower())).Select(x => x).ToList();

        }

        public void DeletePerson(int id)
        {
            _db.Remove(GetPersonByID(id));
        }

    }
}