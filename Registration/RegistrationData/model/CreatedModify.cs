using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationData
{
    public class CreatedModify
    {
        [Column("created@")]
        public DateTime CreatedAt { get; set; }

        [Column("modify@")]
        public DateTime? ModifiedAt { get; set; }

    }
}
