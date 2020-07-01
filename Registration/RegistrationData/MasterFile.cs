using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationData
{
    [Table("master_file")]
    public class MasterFile : CreatedModify
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("sv_nr")]
        public int? SVNumber { get; set; }

        [Column("geb_date")]
        public DateTime? Birthday { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("busy")]
        public string Busy { get; set; }

        [Column("busy_by")]
        public string BusyAt { get; set; }

        [Column("picture")]
        public string Picture { get; set; }

        [Column("function")]
        public string Function { get; set; }

        [Column("aktiv")]
        public bool Active { get; set; }

        [Column("deleted _naktiv")]
        public bool DeletedInactive { get; set; }

        [Column("newsletter_flag")]
        public bool NewsletterFlag { get; set; }

        public Address Address { get; set; }

    }
}
