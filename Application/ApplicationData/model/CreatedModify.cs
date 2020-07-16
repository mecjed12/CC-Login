using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationData
{
    public class CreatedModify
    {
        [Column("created@")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("modified@")]
        public DateTime? ModifiedAt { get; set; }

    }
}
