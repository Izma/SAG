using SAG.Interfaces;
using SAG.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SAG.Controllers
{
    [RoutePrefix("api/person")]
    [Authorize]
    public class PersonController : ApiController
    {
        private readonly IPerson _repository;
        public PersonController(IPerson repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetPerson()
        {
            return Ok(new List<object>() {
                new { nombre = "Ismael", apaterno = "López", amaterno = "Aguilar", edad=29 },
                new { nombre = "Abdiel", apaterno = "López", amaterno = "Soto", edad=4 },
                new { nombre = "Ameli", apaterno = "Soto", amaterno = "Flores", edad=29 }
            });
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddPerson(PersonModel model)
        {
            var result = await _repository.AddPerson(model);
            if (result.Msg.Equals("success"))
                return Ok(result);
            else
                return InternalServerError();
        }
    }
}
