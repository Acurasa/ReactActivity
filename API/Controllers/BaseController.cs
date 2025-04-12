using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase
{
    
}