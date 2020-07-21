using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationData.model
{
	[Table("course_category")]
	public class CourseCategory
	{
		public int Id { get; set; }

		[Column("category")]
		public string Name { get; set; }

		public string Color { get; set; } = "#6CFACB";

		[Column("font_color")]
		public string FontColor { get; set; } = "#00426A";
	}
}
