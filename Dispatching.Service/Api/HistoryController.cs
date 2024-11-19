using Dispatching.Domain.History;
using Dispatching.Service.UseCase.GetHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Service.Api;

[Route("history")]
public class HistoryController : Controller
{
	#region Data
	#region Fields
	private readonly IMediator _mediator;
	#endregion
	#endregion

	#region .ctor
	public HistoryController(IMediator mediator)
	{
		ArgumentNullException.ThrowIfNull(mediator);
		_mediator = mediator;
	}
	#endregion

	#region Public
	/// <summary>
	/// Возвращает исторические события по участнику.
	/// </summary>
	/// <param name="participantId">Идентификатор участника.</param>
	/// <returns>Исторические события.</returns>
	[HttpPost("get-circuit_board/{participantId}")]
	public async Task<IEnumerable<HistoryEvent>> GetCircuitBoardAsync([FromRoute] Guid participantId) => await _mediator.Send(new HistoryEventsQuery(participantId));
	#endregion
}
