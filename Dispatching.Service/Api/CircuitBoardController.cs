using Dispatching.Service.UseCase.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Service.Api;

[Route("CircuitBoards")]
public class CircuitBoardController : Controller
{
	#region Data
	#region Fields
	private readonly ILogger<CircuitBoardController> _logger;
	private readonly IMediator _mediator;
	#endregion
	#endregion

	#region .ctor
	public CircuitBoardController(ILogger<CircuitBoardController> logger, IMediator mediator)
	{
		ArgumentNullException.ThrowIfNull(logger);
		ArgumentNullException.ThrowIfNull(mediator);
		_logger = logger;
		_mediator = mediator;
	}
	#endregion

	#region Public
	[HttpPost]
	public async Task<IActionResult> CreateCircuitBoard(string name)
	{
		var result = await _mediator.Send(new CreateCircuitBoardCommand(name));
		return Ok(result.ToString());
	}
	#endregion
}
