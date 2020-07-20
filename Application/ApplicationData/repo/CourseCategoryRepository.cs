using ApplicationData.model;
using System;
using System.Linq;

namespace ApplicationData.repo
{
	public class CourseCategoryRepository : Repository<CourseCategory>
	{
		public CourseCategoryRepository(DcvEntities entities) : base(entities)
		{
		}

		public override CourseCategory GetOne(CourseCategory category)
		{
			var name = category.Name;
			var arrName = name.Contains(" ") ? name.Split(' ') : null;

			return Entities.CourseCategories.FirstOrDefault(x => x.Name.Replace(" ", "").Equals(name.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
		}
	}
}
