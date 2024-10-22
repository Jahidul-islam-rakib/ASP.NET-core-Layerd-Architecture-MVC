﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryManageModel.Entities;
//using Newtonsoft.Json;


namespace LibraryManageRepository.DbConfigure
{
	public class LibraryDBContext : DbContext
	{
		public LibraryDBContext(DbContextOptions<LibraryDBContext>options): base(options)
		{

		}
		

		public DbSet<Book> Books { get; set; }
		public DbSet<Student> Students { get; set; }
	}
}