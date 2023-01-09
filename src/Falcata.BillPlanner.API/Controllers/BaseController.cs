using Microsoft.AspNetCore.Mvc;

namespace Falcata.BillPlanner.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    [HttpGet]
    public string Index()
    {
        return "Hello world";
    }
}