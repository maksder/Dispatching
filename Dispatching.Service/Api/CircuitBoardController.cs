using Dispatching.Domain.CircuitBoards;
using Dispatching.Service.UseCase.AddComponent;
using Dispatching.Service.UseCase.Create;
using Dispatching.Service.UseCase.GetCircuitBoard;
using Dispatching.Service.UseCase.Pack;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Service.Api;

[Route("circuit-boards")]
public class CircuitBoardController : Controller
{
	#region Data
	#region Fields
	private readonly IMediator _mediator;
	#endregion
	#endregion

	#region .ctor
	public CircuitBoardController(ILogger<CircuitBoardController> logger, IMediator mediator)
	{
		ArgumentNullException.ThrowIfNull(logger);
		ArgumentNullException.ThrowIfNull(mediator);
		_mediator = mediator;
	}
	#endregion

	#region Public
	/// <summary>
	/// Добавляет компонент к плате.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <param name="componentName">Наименование компонента.</param>
	/// // todo выглядит так, что компонент эта независимая сущность и создаваться должна отдельно (резистор, транзистор и т.д.) и тут только идентификатор надо переделать, но в задании не расписано об это, поэтому сделано так.
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("component")]
	public async Task<IActionResult> AddComponentForCreateCircuitBoardAsync([FromQuery] Guid id, [FromQuery] string componentName)
	{
		await _mediator.Send(new AddComponentForCircuitBoardCommand(id, componentName));
		return Ok();
	}

	/// <summary>
	/// Создает печатную плату.
	/// </summary>
	/// <param name="name">Наименование  платы.</param>
	/// <returns>Идентификатор платы.</returns>
	[HttpPost("registration")]
	public async Task<IActionResult> CreateCircuitBoardAsync([FromQuery] string name)
	{
		var result = await _mediator.Send(new CreateCircuitBoardCommand(name));
		return Ok(result.ToString());
	}

	/// <summary>
	/// Возвращает плату по идентфикатору.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("get-circuit-board/{id}")]
	public async Task<ActionResult<CircuitBoard?>> GetCircuitBoardAsync([FromRoute] Guid id)
	{
		var result = await _mediator.Send(new CircuitBoardQuery(id));
		return result == null ? NotFound() : result;
	}

	/// <summary>
	/// Производит упаковку платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("packing")]
	public async Task<IActionResult> PackCircuitBoard([FromQuery] Guid id)
	{
		await _mediator.Send(new PackCircuitBoardCommand(id));
		return Ok();
	}
	#endregion
}
