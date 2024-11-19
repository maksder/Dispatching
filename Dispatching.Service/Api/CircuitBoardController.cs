using Dispatching.Domain.CircuitBoards;
using Dispatching.Service.UseCase.AddComponent;
using Dispatching.Service.UseCase.AddToQualityControl;
using Dispatching.Service.UseCase.Create;
using Dispatching.Service.UseCase.GetCircuitBoard;
using Dispatching.Service.UseCase.Pack;
using Dispatching.Service.UseCase.Repair;
using Dispatching.Service.UseCase.SetQualityControlResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Service.Api;

[Route("CircuitBoards")]
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
	[HttpPost("Components")]
	public async Task<IActionResult> AddComponentForCreateCircuitBoardAsync([FromQuery] Guid id, [FromQuery] string componentName)
	{
		await _mediator.Send(new AddComponentForCircuitBoardCommand(id, componentName));
		return Ok();
	}

	/// <summary>
	/// Добавляет компонент к плате.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <param name="componentName">Наименование компонента.</param>
	/// // todo выглядит так, что компонент эта независимая сущность и создаваться должна отдельно (резистор, транзистор и т.д.) и тут только идентификатор надо переделать, но в задании не расписано об это, поэтому сделано так.
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("get-circuit_board")]
	public async Task<ActionResult<CircuitBoard?>> GetCircuitBoardAsync([FromQuery] Guid id)
	{
		var result = await _mediator.Send(new CircuitBoardQuery(id));
		return result == null ? NotFound() : result;
	}

	/// <summary>
	/// Создает печатную плату.
	/// </summary>
	/// <param name="name">Наименование  платы.</param>
	/// <returns>Идентификатор платы.</returns>
	[HttpPost("Registration")]
	public async Task<IActionResult> CreateCircuitBoardAsync([FromQuery] string name)
	{
		var result = await _mediator.Send(new CreateCircuitBoardCommand(name));
		return Ok(result.ToString());
	}

	/// <summary>
	/// Производит контроль качества для платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("QualityControl")]
	public async Task<IActionResult> MakeQualityControlForCircuitBoardAsync([FromQuery] Guid id)
	{
		await _mediator.Send(new MakeQualityControlForCircuitBoardCommand(id));
		return Ok();
	}

	/// <summary>
	/// Производит упаковку платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("Packing")]
	public async Task<IActionResult> PackCircuitBoard([FromQuery] Guid id)
	{
		await _mediator.Send(new PackCircuitBoardCommand(id));
		return Ok();
	}

	/// <summary>
	/// Производит ремонт платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("Repairing")]
	public async Task<IActionResult> RepairCircuitBoard([FromQuery] Guid id)
	{
		await _mediator.Send(new RepairCircuitBoardCommand(id));
		return Ok();
	}

	/// <summary>
	/// Устанавливает результат контроль качества для платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <param name="qualityControlResult">Результат контроля качества.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("QualityControl/Result")]
	public async Task<IActionResult> SetQualityControlResultForCircuitBoard([FromQuery] Guid id, [FromQuery] bool qualityControlResult)
	{
		await _mediator.Send(new SetQualityControlResultForCircuitBoardCommand(id, qualityControlResult));
		return Ok();
	}
	#endregion
}
