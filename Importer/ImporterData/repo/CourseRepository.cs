using ImporterData.model;

namespace ImporterData.repo
{
	public class CourseRepository : Repository<Course>
	{
		public CourseRepository(DcvEntities entities) : base(entities)
		{
		}
	}
}
