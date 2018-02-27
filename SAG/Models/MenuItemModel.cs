using System.Collections.Generic;

namespace SAG.Models
{
    public class MenuItemModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public List<MenuItemModel> SubItems { get; set; }
    }
}