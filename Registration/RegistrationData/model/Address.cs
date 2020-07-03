using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationData
{
    [Table("address")]
    public class Address : CreatedModify
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("street")]
        public string Street { get; set; }
        
        [Column("place")]
        public string Place { get; set; }

        [Column("zip")]
        public int? ZipCode { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("contact_type")]
        public string ContactType { get; set; }

        [Column("billing_address")]
        public byte? BillingAdress { get; set; }

        public List<PersonAddress> PAddress { get; set; }
    }
}
