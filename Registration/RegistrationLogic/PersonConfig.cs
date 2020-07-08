using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationLogic
{
    public class PersonConfig
    {
        public int Name1 { get; set; }
        public int Name2 { get; set; }
        public int? Title { get; set; }
        public int? SVNumber { get; set; }
        public int? Date { get; set; }
        public int? Gender { get; set; }
        public int? Active { get; set; }
		public int? DeletedInactive { get; set; }
		public int? NewsletterFlag { get; set; }

		//TODO add more if needed
	}
}
