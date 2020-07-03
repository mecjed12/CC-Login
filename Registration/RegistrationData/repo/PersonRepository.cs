using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            Entities.People.Include(x => x.PAddress).AsNoTracking().ToList();
        }

    }
}
