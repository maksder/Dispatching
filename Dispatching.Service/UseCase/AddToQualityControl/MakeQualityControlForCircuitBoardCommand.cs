using MediatR;

namespace Dispatching.Service.UseCase.AddToQualityControl;

/// <summary>
/// Представляет команду проведения контроль качества для платы.
/// </summary>
public class MakeQualityControlForCircuitBoardCommand : IRequest<bool>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="MakeQualityControlForCircuitBoardCommand" />.
	/// </summary>
	/// <param name="circuitBoardId">Идентификатор платы.</param>
	public MakeQualityControlForCircuitBoardCommand(Guid circuitBoardId)
	{
		CircuitBoardId = circuitBoardId;
	}
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает идентификатор платы.
	/// </summary>
	public Guid CircuitBoardId
	{
		get;
	}
	#endregion
}
