using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.web.Models
{
	public class Visitor
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Comment { get; set; }
		public DateTime Created { get; set; }

	}
}

