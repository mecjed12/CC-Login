using ImporterData.model;
using System;
using System.Linq;

namespace ImporterData.repo
{
	public class CourseCategoryRepository : Repository<CourseCategory>
	{
		public CourseCategoryRepository(DcvEntities entities) : base(entities)
		{
		}
		//TODO Add more checks maybe
		public override CourseCategory Get(CourseCategory category)
		{
			return Entities.CourseCategories.FirstOrDefault(x => x.Name.Replace(" ", "").Equals(category.Name.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
		}
	}
}
