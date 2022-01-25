﻿namespace RestBook.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string? Publisher { get; set; }
		public string? Title { get; set; } 
		public string? AuthorLastName { get; set; }
		public string? AuthorFirstName { get; set; }
		public decimal? Price { get; set; }
	}
}