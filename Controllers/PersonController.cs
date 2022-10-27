using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinqWebApi.Models;

namespace LinqWebApi.Controllers
{
    public class PersonController : ApiController
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        // GET: api/Person
        public IEnumerable<Employee> Get()
        {
            var ps = from p in db.Employees 
                     select p;
            return ps.AsEnumerable();
        }

        // GET: api/Person/5
        public IEnumerable<Employee> Get(int id)
        {
            var ps = from p in db.Employees where p.EmpId == id 
                     select p;
            return ps.AsEnumerable();
        }

        // POST: api/Person
        public void Post([FromBody]Employee newPerson)
        {
            db.Employees.InsertOnSubmit(newPerson);
            db.SubmitChanges();
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]Employee updatePerson)
        {
            Employee newPerson = db.Employees.FirstOrDefault(p => p.EmpId.Equals(id));
            newPerson.EmpName = updatePerson.EmpName;
            newPerson.Password = updatePerson.Password;
            db.SubmitChanges();
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            Employee deletePerson = db.Employees.FirstOrDefault(p => p.EmpId.Equals(id));
            db.Employees.DeleteOnSubmit(deletePerson);
            db.SubmitChanges();
        }
    }
}
