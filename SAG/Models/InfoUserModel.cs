using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class InfoUserModel
    {
        public string UserId { get; set; }
        public string LastSession { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
    }
}