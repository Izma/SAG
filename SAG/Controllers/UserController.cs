using SAG.Interfaces;
using SAG.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace SAG.Controllers
{
    [RoutePrefix("api/user")]
    [JwtAuthentication]
    public class UserController : ApiController
    {
        private readonly IUser _repository;
        public UserController(IUser repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUser(UserModel model)
        {
            var result = await _repository.AddUser(model);
            if (result.Msg.Equals("success"))
                return Ok(result);
            else
                return BadRequest(result.Msg);
        }
    }
}
