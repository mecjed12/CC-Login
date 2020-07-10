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

        [ApplicationProperty("Titel")]
        public string Title { get; set; }

        [Column("course_number")]
        public string CourseNumber { get; set; }

        [ApplicationProperty("Beschreibung")]
        public string Description { get; set; }

        [ApplicationProperty("Kategorie")]
        public string Category { get; set; }

        [ApplicationProperty("Started am")]
        public DateTime? Start { get; set; }

        [ApplicationProperty("Endet am")]
        public DateTime? End { get; set; }

        public int? Unit { get; set; }

        public double? Price { get; set; }

        [ApplicationProperty("Minimale Teilnehmer")]
        [Column("participant_min")]
        public int? MinParticipants { get; set; }

        [ApplicationProperty("Maximale Teilnehmer")]
        [Column("participant_max")]
        public int? MaxParticipants { get; set; }

        [Column("classroom_id")]
        public int? ClassroomId { get; set; }

        //Delete ones database updates
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
