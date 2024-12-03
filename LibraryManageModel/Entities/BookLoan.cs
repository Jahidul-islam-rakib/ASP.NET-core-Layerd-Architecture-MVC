using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageModel.Entities
{
	public class BookLoan
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string BookId { get; set; }
		public string BookName { get; set; }
    }
}
