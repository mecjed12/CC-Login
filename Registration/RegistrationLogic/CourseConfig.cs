using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationLogic
{
	public class CourseConfig
	{
		public int Title { get; set; }
		public int? CourseNumber { get; set; }
		public int? Description { get; set; }
		public int Category { get; set; }
		public int? Start { get; set; }
		public int? End { get; set; }
		public int? Unit { get; set; }
		public int? Price { get; set; }
		public int? ClassroomId { get; set; }
		public int? ParticipantsMax { get; set; }
		public int? ParticipantsMin { get; set; }
	}
}
