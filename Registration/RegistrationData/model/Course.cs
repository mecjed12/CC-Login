using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationData.model
{
    
    public class Course // : CreatedModify
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Column("course_number")]
        public string Coursenumber { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int? Unit { get; set; }

        public double? Price { get; set; }

        [Column("participant_max")]
        public int ParticipantMax { get; set; }
        
        [Column("participant_min")]
        public int ParticipantMin { get; set; }

        [Column("classroom_id")]
        public int ClassroomId { get; set; }

        //Delete ones database updates
        [Column("created@")]
        public DateTime? CreatedAt { get; set; }

        [Column("modified@")]
        public DateTime? ModifiedAt { get; set; }
    }
}
