using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWithBackend.Data
{
    public class PersonRepo
    {
        private readonly string _connectionString;

        public PersonRepo(string connectionString)
        {
            _connectionString = connectionString;    
        }

        public List<Person> GetAll()
        {
            using var context = new PeopleDataContext(_connectionString);
            return context.People.ToList();
        }

        public void Add(Person person)
        {
            using var context = new PeopleDataContext(_connectionString);
            context.People.Add(person);
            context.SaveChanges();
        }
    }
}
