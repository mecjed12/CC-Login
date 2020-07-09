using ApplicationData.model;

namespace ApplicationData.repo
{
	public class CourseRepository : Repository<Course>
	{
		public CourseRepository(DcvEntities entities) : base(entities)
		{
		}
	}
}
