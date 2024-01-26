using System.Text;
using Falcata.BillPlanner.Application.Feature.MediatorTest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Falcata.BillPlanner.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
}