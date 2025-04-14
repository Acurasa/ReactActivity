using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebApplication1.Controllers;

public class ActivitiesController(AppDbContext dbContext) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        var activity = Mediator.Send(new GetActivityDetails.Query{Id = id});
        return activity.Result;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        var created = await Mediator.Send(new CreateActivityCommand.Command {Activity = activity});


        return created;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateActivity(Activity activity)
    {
        await Mediator.Send((new UpdateActivityCommand.Command() { Activity = activity }));

        return NoContent();
    }
}