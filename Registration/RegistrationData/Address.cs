using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationData
{
    [Table("address")]
    public class Address : CreatedModify
    {
        [Column("id")]
        public int Id { get; set; }

        public string Street { get; set; }
        
        public string Place { get; set; }

        public int? ZipCode { get; set; }

        public string Country { get; set; }

        public string ContactType { get; set; }

        public byte? BillingAdress { get; set; }



        [Column("master_file_id")]
        public int MasterId { get; set; }
        public MasterFile Master { get; set; }

    }
}
