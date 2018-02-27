using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class ValidateModel
    {
        public Code Code { get; set; }
        public string UserId { get; set; }
    }

    public enum Code
    {
        SUCCESS = 1,
        PASSWORD_WRONG = 2,
        EMAIL_WRONG = 3
    }
}