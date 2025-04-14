using Application.Activities.ManualMappings;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Activities.Commands;

public class UpdateActivityCommand
{
    public class Command : IRequest
    {
        public Activity Activity { get; set; }
    }
    
    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await context.Activities.FindAsync(request.Activity.Id,cancellationToken) ??
                         throw new Exception($"No result with ID :{request.Activity.Id}");

            MapAuto.Map<Activity>(request.Activity, entity);

            await context.SaveChangesAsync();
        }
    }
}