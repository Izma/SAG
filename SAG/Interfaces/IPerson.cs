using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAG.Models;

namespace SAG.Interfaces
{
    public interface IPerson
    {
        Task<Result> AddPerson(PersonModel model);
    }
}
