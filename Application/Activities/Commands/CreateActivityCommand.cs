using System.Dynamic;
using Domain.Entities;
using MediatR;
using Persistance;

namespace Application.Activities.Commands;

public class CreateActivityCommand
{
    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set; }
    }
    
    public class Handler(AppDbContext context) : IRequestHandler<Command,string >
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.Activity);

            await context.SaveChangesAsync(cancellationToken);

            return request.Activity.Id;
        }
    }
}