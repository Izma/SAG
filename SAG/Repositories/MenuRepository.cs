using Dapper;
using SAG.Interfaces;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SAG.Repositories
{
    public class MenuRepository : BaseRepository, IMenu
    {
        public MenuRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<MenuModel>> GetMenu()
        {
            return await WithConnection(async c =>
            {
                var result = await c.QueryAsync<MenuModel>(
                   sql: "[dbo].[sp_GetMenu]",
                   commandType: CommandType.StoredProcedure);
                return result.AsEnumerable();
            });
        }

        public Task<MenuModel> GetMenu(int menuId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> SaveMenu(MenuModel model)
        {
            throw new NotImplementedException();
        }
    }
}