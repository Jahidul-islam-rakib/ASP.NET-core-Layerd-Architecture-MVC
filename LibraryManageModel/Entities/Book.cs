using LibraryManageModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageModel.Entities
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Auther { get; set; }
		public string Isbn { get; set; }
	}

	//public class BookAuditTrial : BaseAuditTrialVM
	//{
	//	public string Title { get; set; }
	//	public string Auther { get; set; }
	//	public string Isbn { get; set; }

	//}
}
