using Application.Activities.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebApplication1.Controllers;

public class ActivitiesController(AppDbContext dbContext, IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        var activity = mediator.Send(new GetActivityDetails.Query{Id = id});
        return activity.Result;
    }
}