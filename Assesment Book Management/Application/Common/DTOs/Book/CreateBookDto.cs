using System;
using System.Collections.Generic;
// using Application.Common.DTOs.Common;

namespace Application.Common.DTOs.Book;

public class CreateBookDTO : IBookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public int ReleaseYear { get; set; }
}


