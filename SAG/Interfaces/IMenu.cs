using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAG.Models;

namespace SAG.Interfaces
{
   public interface IMenu
    {
        Task<IEnumerable<MenuModel>> GetMenu();
        Task<MenuModel> GetMenu(int menuId);
        Task<Result> SaveMenu(MenuModel model);
    }
}
