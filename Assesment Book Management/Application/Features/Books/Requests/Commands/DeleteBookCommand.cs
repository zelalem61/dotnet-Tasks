using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Books.Requests.Commands;

public class DeleteBookCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}
