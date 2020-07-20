using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationData
{
    public class CreatedModified
    {
        public int Id { get; set; }

        [Column("created@")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("modified@")]
        public DateTime? ModifiedAt { get; set; }

    }
}
