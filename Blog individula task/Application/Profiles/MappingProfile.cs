using AutoMapper;
using Application.Common.DTOs.Blog;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Blog, BlogDTO>().ReverseMap();
        CreateMap<Blog, CreateBlogDTO>().ReverseMap();
        CreateMap<Blog, UpdateBlogDTO>().ReverseMap();

    }
}

