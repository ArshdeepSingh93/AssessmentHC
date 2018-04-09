using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentHC.Models
{
   public interface IPersonRepository
    {
        void CreateNewPerson(Person personToCreate);
        void DeletePerson(int id);
        Person GetPersonByID(int id);
        IEnumerable<Person> GetAllPersons();
        IEnumerable<Person> GetAllPersonsByName(string searchText);
        int SaveChanges();
    }
}
