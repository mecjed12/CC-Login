using ApplicationData.attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	public class Course : CreatedModify, IApplicationClass
    {
        public int Id { get; set; }

        [ApplicationProperty(DisplayName = "Titel")]
        public string Title { get; set; }

        [Column("course_number")]
        public string CourseNumber { get; set; }

        [ApplicationProperty(DisplayName = "Beschreibung")]
        public string Description { get; set; }

        [ApplicationProperty(DisplayName = "Kategorie")]
        public string Category { get; set; }

        [ApplicationProperty(DisplayName = "Started am")]
        public DateTime? Start { get; set; }

        [ApplicationProperty(DisplayName = "Endet am")]
        public DateTime? End { get; set; }

        public int? Unit { get; set; }

        public double? Price { get; set; }

        [ApplicationProperty(DisplayName = "Minimale Teilnehmer")]
        [Column("participant_min")]
        public int? MinParticipants { get; set; }

        [ApplicationPropertyAttribute(DisplayName = "Maximale Teilnehmer")]
        [Column("participant_max")]
        public int? MaxParticipants { get; set; }

        //TODO remove
        [Obsolete]
        [Column("classroom_id")]
        public int? ClassroomId { get; set; }

		public List<PropertyInfo> GetProperties()
		{
            var CourseProps = GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationPropertyAttribute), true)).ToList();

            return CourseProps;
		}

        public List<IApplicationSubclass> GetSubclasses()
        {
            return new List<IApplicationSubclass> { };
        }

		public List<PropertyInfo> GetSubclassProperties()
		{
            return new List<PropertyInfo> { };

		}
	}
}
