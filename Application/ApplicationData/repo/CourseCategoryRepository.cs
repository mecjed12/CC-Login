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
		//TODO Add more checks maybe
		public override CourseCategory GetOne(CourseCategory category)
		{
			return Entities.CourseCategories.FirstOrDefault(x => x.Name.Replace(" ", "").Equals(category.Name.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
		}
	}
}
