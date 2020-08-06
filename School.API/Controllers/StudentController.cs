using School.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School.API.Controllers
{
    public class StudentController : ApiController
    {

        public static List<Student> students = new List<Student> { 
            new Student{ Id = 1, FirstName="Samuel", LastName = "Legrain"},
            new Student{ Id = 2, FirstName="Cédric", LastName = "Pietquin"},
            new Student{ Id = 3, FirstName="Hanen", LastName = "Ben Hassine"},
            new Student{ Id = 4, FirstName="Jérémy", LastName = "Samyn"},
            new Student{ Id = 5, FirstName="Olivier", LastName = "Paquet"},
            new Student{ Id = 6, FirstName="Rachid", LastName = "Aferyad"},
            new Student{ Id = 7, FirstName="Victor", LastName = "Kabela"},
            new Student{ Id = 8, FirstName="Xavier", LastName = "Dubois"},
            new Student{ Id = 9, FirstName="Yusuf", LastName = "Ozdemir"}
        };

        //GET : api/Student/
        public IEnumerable<Student> Get()
        {
            return students;
        }
        //GET : api/Student/{id}
        [Route("api/Student/{id:StudentIdExist}")]
        public Student Get(int id)
        {
            return students.Where(s => s.Id == id).SingleOrDefault();
        }
        //POST : api/Student/
        public int Post(Student entity)
        {
            entity.Id = students.Max(s => s.Id) + 1;
            students.Add(entity);
            return entity.Id;
        }
        //PUT : api/Student/{id}
        public void Put(int id, Student entity)
        {
            Student s = Get(id);
            if (s is null) return; //Exception
            s.FirstName = entity.FirstName;
            s.LastName = entity.LastName;
        }

        //DELETE : api/Student/{id}
        public void Delete(int id)
        {
            Student s = Get(id);
            if (s is null) return; //Exception
            students.Remove(s);
        }
        [HttpPut]
        [HttpPatch]
        [Route("Toto/{id:alpha:maxlength(12):regex(^A)}")]
        public string TestToto(string id)
        {
            return id;
        }
    }
}
