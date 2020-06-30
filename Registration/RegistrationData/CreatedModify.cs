using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationData
{
    public class CreatedModify
    {
        [Column("created@")]
        public DateTime CreatedAt { get; set; }

        [Column("modify@")]
        public DateTime ModifiedAt { get; set; }

    }
}
