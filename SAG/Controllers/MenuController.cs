using SAG.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SAG.Models;
using System.Linq;
using SAG.Helpers;

namespace SAG.Controllers
{
    [RoutePrefix("api/menu")]
    [AllowAnonymous]
    public class MenuController : ApiController
    {
        private readonly IMenu repository;
        public MenuController(IMenu _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetMenu()
        {
            var result = await repository.GetMenu();
            IEnumerable<MenuItemModel> menuList = result.RecursiveJoin(item => item.MenuID, item => item.ParentID,
                (MenuModel element, IEnumerable<MenuItemModel> children) => new MenuItemModel()
                {
                    Title = element.Description,
                    Link = element.Route,
                    SubItems = children.ToList()
                }).ToList();
            if (menuList.Count() > 0)
            {
                return Ok(menuList);
            }

            return NotFound();
        }


    }
}
