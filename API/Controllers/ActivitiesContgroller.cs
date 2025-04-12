using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebApplication1.Controllers;

public class ActivitiesController(AppDbContext dbContext)  : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await dbContext.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        var activity = await dbContext.Activities.FindAsync(id);
        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }
    
}