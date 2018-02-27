using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class PersonModel
    {
        public string PersonID { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Genere { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string UserRegister { get; set; }
    }
}