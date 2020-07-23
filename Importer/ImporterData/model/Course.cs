using ImporterData;
using ImporterData.repo;
using ImporterData.attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ImporterData.model
{
	[Display(Name = "Kurse")]
	[Table("course")]
	public class Course : CreatedModified, IImportClass
	{
		[ImportProperty(DisplayName = "Titel", Required = true, Index = 0)]
		public string Title { get; set; }

		[ImportProperty(DisplayName = "Kurse Nummer", Index = 3)]
		[Column("course_number")]
		public string CourseNumber { get; set; }

		[ImportProperty(DisplayName = "Beschreibung", Index = 2)]
		public string Description { get; set; }

		[ImportProperty(DisplayName = "Started am", Index = 7)]
		public DateTime? Start { get; set; }

		[ImportProperty(DisplayName = "Endet am", Index = 7)]
		public DateTime? End { get; set; }

		[ImportProperty(DisplayName = "Einheiten", Index = 5)]
		public int? Unit { get; set; }

		[ImportProperty(DisplayName = "Preis", Index = 4)]
		public double? Price { get; set; }

		[ImportProperty(DisplayName = "Minimale Teilnehmer", Index = 6)]
		[Column("participant_min")]
		public int? MinParticipants { get; set; }

		[ImportProperty(DisplayName = "Maximale Teilnehmer", Index = 6)]
		[Column("participant_max")]
		public int? MaxParticipants { get; set; }

		[ImportProperty(DisplayName = "Kategorie", Required = true, Index = 1)]
		[NotMapped]
		public string Category
		{
			get => _category;
			set
			{
				CourseCategoryRepository repo = new CourseCategoryRepository(new DcvEntities());
				CourseCategory category = new CourseCategory() { Name = value };
				if (repo.Get(category) is CourseCategory c)
				{
					_category = c.Name;
				}
				else
				{
					_category = category.Name;
					repo.Add(category);
				}
			}
		}

		[Column("category")]
		public string _category { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			var CourseProps = GetType().GetProperties().Where(x => x.IsDefined(typeof(ImportPropertyAttribute), true)).ToList();

			return CourseProps;
		}

		public List<IImportSubclass> GetSubclasses()
		{
			return null;
		}
	}
}
