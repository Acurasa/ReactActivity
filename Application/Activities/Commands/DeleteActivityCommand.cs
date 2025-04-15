using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Activities.Commands;

public class DeleteActivityCommand
{
    public class Command : IRequest
    {
        public string Id { get; set; }
    }


    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entityForDeletion = await context.Activities.FindAsync(request.Id, cancellationToken)
                                    ?? throw new Exception($"Cannot find entity with id {request.Id}");

            context.Remove(entityForDeletion);

            await context.SaveChangesAsync(cancellationToken);

        }
    }
}