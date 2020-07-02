using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationData.repo
{
    public class PersonRepository : IRepository<Person>
    {
        readonly DcvEntities Entities;

        public PersonRepository(DcvEntities entities)
        {
            Entities = entities;
        }

        public void InitRepository()
        {
            Entities.People.Include(x => x.PAddress).ToList();
        }

    }
}
