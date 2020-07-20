using ApplicationData.attribute;
using ApplicationData.repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	[Display(Name = "Kurse")]
	[Table("course")]
	public class Course : CreatedModified, IApplicationClass
	{
		[ApplicationProperty(DisplayName = "Titel", Required = true, Index = 0)]
		public string Title { get; set; }
		
		[ApplicationProperty(DisplayName = "Kurse Nummer", Index = 3)]
		[Column("course_number")]
		public string CourseNumber { get; set; }

		[ApplicationProperty(DisplayName = "Beschreibung", Index = 2)]
		public string Description { get; set; }

		[ApplicationProperty(DisplayName = "Started am", Index = 7)]
		public DateTime? Start { get; set; }

		[ApplicationProperty(DisplayName = "Endet am", Index = 7)]
		public DateTime? End { get; set; }

		[ApplicationProperty(DisplayName = "Einheiten", Index = 5)]
		public int? Unit { get; set; }

		[ApplicationProperty(DisplayName = "Preis", Index = 4)]
		public double? Price { get; set; }

		[ApplicationProperty(DisplayName = "Minimale Teilnehmer", Index = 6)]
		[Column("participant_min")]
		public int? MinParticipants { get; set; }

		[ApplicationProperty(DisplayName = "Maximale Teilnehmer", Index = 6)]
		[Column("participant_max")]
		public int? MaxParticipants { get; set; }

		//TODO do this different
		[ApplicationProperty(DisplayName = "Kategorie", Required = true, Index = 1)]
		[NotMapped]
		public string Category
		{
			get => _category;
			set
			{
				CourseCategoryRepository repo = new CourseCategoryRepository(new DcvEntities());
				CourseCategory category = new CourseCategory() { Name = value };
				if (repo.GetOne(category) is CourseCategory c)
				{
					_category = c.Name;
				}
				else
				{
					repo.Add(category);
					_category = category.Name;
				}
			}
		}

		[Column("category")]
		public string _category;

		public List<PropertyInfo> GetProperties()
		{
			var CourseProps = GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationPropertyAttribute), true)).ToList();

			return CourseProps;
		}

		public List<IApplicationSubclass> GetSubclasses()
		{
			return null;
		}
	}
}
