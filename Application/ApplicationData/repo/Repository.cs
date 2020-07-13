﻿using System.Collections.Generic;
using System.Linq;

namespace ApplicationData.repo
{
    public abstract class Repository<T> where T : class
    {

        protected readonly DcvEntities Entities;

        public Repository(DcvEntities entities)
        {
            Entities = entities;
        }

        public virtual List<T> GetAll()
        {
            return Entities.Set<T>().ToList();
        }
    }
}
