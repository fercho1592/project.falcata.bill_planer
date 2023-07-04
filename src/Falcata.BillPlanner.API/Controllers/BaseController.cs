using System.Text;
using Falcata.BillPlanner.Application.Feature.MediatorTest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Falcata.BillPlanner.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet]
    public async Task<string> Index()
    {
        StringBuilder srtResult = new StringBuilder("Hello world");

        var mediatorResult = await _mediator.Send(new MediatorTestQuery());

        srtResult.AppendLine($"MediatoR Test: {mediatorResult}");
        
        return srtResult.ToString();
    }
}