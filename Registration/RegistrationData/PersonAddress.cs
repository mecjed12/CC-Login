using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationData
{
    [Table("adressperson")]
    public class PersonAddress
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("adressId")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Column("personId")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
