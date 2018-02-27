using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class MenuModel
    {
        public int ?MenuID { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public int ParentID { get; set; }
        public bool IsActive { get; set; }
        public string UserRegister { get; set; }
    }
}