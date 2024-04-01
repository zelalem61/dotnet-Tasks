using AutoMapper;
using Application.Common.DTOs.Book;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<Book, CreateBookDTO>().ReverseMap();
        CreateMap<Book, UpdateBookDTO>().ReverseMap();

    }
}

