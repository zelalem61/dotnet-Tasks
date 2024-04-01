using System;
using System.Collections.Generic;

namespace Application.Common.DTOs.Book;

public class BookDTO : IBookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public int ReleaseYear { get; set; }
}



