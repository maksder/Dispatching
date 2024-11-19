using Dispatching.Service.UseCase.AddToQualityControl;
using Dispatching.Service.UseCase.Repair;
using Dispatching.Service.UseCase.SetQualityControlResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Service.Api;

[Route("quality-control")]
public class QualityControlController : Controller
{
	#region Data
	#region Fields
	private readonly IMediator _mediator;
	#endregion
	#endregion

	#region .ctor
	public QualityControlController(IMediator mediator)
	{
		ArgumentNullException.ThrowIfNull(mediator);
		_mediator = mediator;
	}
	#endregion

	#region Public
	/// <summary>
	/// Производит контроль качества для платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost]
	public async Task<IActionResult> MakeQualityControlForCircuitBoardAsync([FromQuery] Guid id)
	{
		await _mediator.Send(new MakeQualityControlForCircuitBoardCommand(id));
		return Ok();
	}

	/// <summary>
	/// Производит ремонт платы.
	/// </summary>
	/// <param name="id">Идентификатор платы.</param>
	/// <returns>Результат выполнения запроса.</returns>
	[HttpPost("repairing")]
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
	[HttpPost("result")]
	public async Task<IActionResult> SetQualityControlResultForCircuitBoard([FromQuery] Guid id, [FromQuery] bool qualityControlResult)
	{
		await _mediator.Send(new SetQualityControlResultForCircuitBoardCommand(id, qualityControlResult));
		return Ok();
	}
	#endregion
}
