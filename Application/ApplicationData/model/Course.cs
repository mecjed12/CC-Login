using ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	public class Course : IApplicationClass
    {
        public int Id { get; set; }

        [ApplicationProperty]
        public string Title { get; set; }

        [Column("course_number")]
        public string CourseNumber { get; set; }

        [ApplicationProperty]
        public string Description { get; set; }

        [ApplicationProperty]
        public string Category { get; set; }

        [ApplicationProperty]
        public DateTime? Start { get; set; }

        [ApplicationProperty]
        public DateTime? End { get; set; }

        public int? Unit { get; set; }

        public double? Price { get; set; }

        [ApplicationProperty]
        [Column("participant_max")]
        public int? MaxParticipants { get; set; }

        [ApplicationProperty]
        [Column("participant_min")]
        public int? MinParticipants { get; set; }

        [Column("classroom_id")]
        public int? ClassroomId { get; set; }

        //Delete ones database updates
        [ApplicationProperty]
        [Column("created@")]
        public DateTime? CreatedAt { get; set; }

        [Column("modified@")]
        public DateTime? ModifiedAt { get; set; }

		public List<PropertyInfo> GetProperties()
		{
            var CourseProps = GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationProperty), true)).ToList();

            return CourseProps;
		}
	}
}
