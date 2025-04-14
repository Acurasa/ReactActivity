using Domain.Entities;
using MediatR;
using Persistance;

namespace Application.Activities.Queries;

public class GetActivityDetails
{
    public class Query : IRequest<Activity>
    {
        public required string Id{ get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity =  await context.Activities.FindAsync(request.Id, cancellationToken);
            if (activity is null)
                throw new Exception(
                    $"Expected type result was null, {nameof(activity)} with Id: {request.Id} was not found.");
            return activity;
        }
    }
}