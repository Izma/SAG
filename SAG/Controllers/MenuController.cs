using SAG.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SAG.Models;
using System.Linq;
using SAG.Helpers;
using SAG.Filters;
using System;

namespace SAG.Controllers
{
    [RoutePrefix("api/menu")]
    [JwtAuthentication]
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
            try
            {
                var result = await repository.GetMenu();
                IEnumerable<MenuItemModel> menuList = result.RecursiveJoin(item => item.MenuID, item => item.ParentID,
                    (MenuModel element, IEnumerable<MenuItemModel> children) => new MenuItemModel()
                    {
                        Title = element.Description,
                        Link = element.Route,
                        SubItems = children.ToList().Count > 0 ? children.ToList() : null
                    }).ToList();
                if (menuList.Count() > 0)
                {
                    return Ok(menuList);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return NotFound();
        }


    }
}
