using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssessmentHC.Models;

namespace AssessmentHC.Models
{
    public class EntityPersonRepository: IPersonRepository
    {

        private PersonContext _db = new PersonContext();

        public Person GetPersonByID(int id)
        {
            return _db.persons.Find(id);
        }

        public IEnumerable<Person> GetAllPersons()
        {
           
            return _db.persons.ToList();
        }
        public IEnumerable<Person> GetAllPersonsByName(string searchText)
        {
            return _db.persons.Where(x => x.FName.Contains(searchText) || x.LName.Contains(searchText)).Select(x => x).ToList();
            
        }

        public void CreateNewPerson(Person personToCreate)
        {
            _db.persons.Add(personToCreate);
            _db.SaveChanges();
            
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var conToDel = GetPersonByID(id);
            _db.persons.Remove(conToDel);
            _db.SaveChanges();
        }
    }
}