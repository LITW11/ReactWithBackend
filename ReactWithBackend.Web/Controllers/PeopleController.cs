using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactWithBackend.Data;
using ReactWithBackend.Web.Models;

namespace ReactWithBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [Route("getall")]
        public List<Person> GetAll()
        {
            //Thread.Sleep(3000);
            var repo = new PersonRepo(_connectionString);
            return repo.GetAll();
        }

        [HttpPost]
        [Route("add")]
        public void Add(Person person)
        {
            //Thread.Sleep(2000);
            var repo = new PersonRepo(_connectionString);
            repo.Add(person);
        }

        [HttpPost]
        [Route("deleteall")]
        public void DeleteAll(DeleteAllViewModel vm)
        {
            // front end code demo:
            //  const idsToDelete = [4,2, 1];
            //  axios.post('/api/people/deleteall', {ids: idsToDelete});

            //use vm.Ids to send to db to delete....
        }
    }
}
