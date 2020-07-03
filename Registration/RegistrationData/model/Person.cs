using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationData
{
    [Table("person")]
    public class Person : BasePerson
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("sv_nr")]
        public int? SVNumber { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("busy")]
        public string Busy { get; set; }

        [Column("busy_by")]
        public string BusyAt { get; set; }

        //Base64
        [Column("picture")]
        public string Picture { get; set; }

        [Column("function")]
        public string Function { get; set; }

        [Column("aktiv")]
        public bool Active { get; set; }

        [Column("deleted_inaktiv")]
        public bool DeletedInactive { get; set; }

        [Column("newsletter_flag")]
        public bool NewsletterFlag { get; set; }


        public List<PersonAddress> PAddress { get; set; }

    }
}
