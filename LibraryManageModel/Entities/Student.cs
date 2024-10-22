using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageModel.Entities
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		public string StName {  get; set; }
		public string ClassNo { get; set; }
		public string MemberId { get; set; }


	}
}
