using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationData
{
    public class CreatedModify
    {
        [ApplicationProperty]
        [Column("created@")]
        public DateTime CreatedAt { get; set; }

        [Column("modify@")]
        public DateTime? ModifiedAt { get; set; }

    }
}
