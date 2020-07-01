using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationData
{
    public class BasePerson : CreatedModify
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name1")]
        public string Name1 { get; set; }

        [Column("name2")]
        public string Name2 { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

    }
}
