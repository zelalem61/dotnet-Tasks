using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BlogApi.Application.DTOs.CommentDto;
using BlogApi.Application.DTOs.PostDto;
using BlogApi.Domain;
using BlogApi.Application.DTOs;


namespace BlogApi.Application.Profiles;

 
public class MappingProfile : Profile
{
    public MappingProfile(){

        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
        CreateMap<Post, PostListDto>().ReverseMap();
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        CreateMap<Comment, CommentListDto>().ReverseMap();

    }

}
