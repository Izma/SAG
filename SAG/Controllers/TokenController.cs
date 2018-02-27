using SAG.Interfaces;
using SAG.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace SAG.Controllers
{

    [RoutePrefix("api/token")]
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        private readonly IValidate validateRepository;
        private readonly IInfoUser infoUserRepository;
        public TokenController(IValidate _validate, IInfoUser _infoUser)
        {
            validateRepository = _validate;
            infoUserRepository = _infoUser;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Demo(int id)
        {
            await Task.Run(() =>
            {
                var user = "Ismael";
            });
            return Ok(id);
        }

        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Validate(LoginModel model)
        {
            var result = await validateRepository.CheckUser(model.Email, model.Password);
            string message = string.Empty;
            switch (result.Code)
            {
                case Code.SUCCESS:
                    var info = await infoUserRepository.GetInfoUser(result.UserId);
                    if (!info.Equals(null))
                    {
                        message = JwtManager.GenerateToken(info);
                    }
                    break;
                case Code.PASSWORD_WRONG:
                    message = "PASSWORD_WRONG";
                    break;
                case Code.EMAIL_WRONG:
                    message = "EMAIL_WRONG";
                    break;
            }
            if (!message.Equals(""))
                return Ok(message);
            return InternalServerError();
        }

        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }
    }
}
