using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssessmentHC;
using AssessmentHC.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using AssessmentHC.Models;
using System.Web.Routing;
using System.Linq;

namespace AssessmentHC.Tests.Controllers
{
    [TestClass]
    public class PersonsControllerTest
    {
       
        Person GetPerson(int id, string fName, string lName)
        {
            return new Person
            {
                Id = id,
                FName = fName,
                LName = lName,
                Age=20,
                Address = "710-555-0173",
                Interests = "Singing"
            };
        }

        private static PersonsController GetPersonsController(IPersonRepository repository)
        {
            PersonsController controller = new PersonsController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        [TestMethod]
        public void Search_verifySearchResults()
        {
            Person p1 = GetPerson(1, "John", "cena");
            Person p2 = GetPerson(2, "John", "Deo");

            InMemoryPersonsRepository repository = new InMemoryPersonsRepository();
            repository.Add(p1);
            repository.Add(p2);
            var controller = GetPersonsController(repository);

            // Act
            PartialViewResult result = controller.Search("John") as PartialViewResult;

            // Assert
            var model = (IEnumerable<Person>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), p1);
            CollectionAssert.Contains(model.ToList(), p2);

        }
        
    }
}
