using MediatR;

namespace Dispatching.Service.UseCase.Repair;

/// <summary>
/// Представляет команду проведения ремонта платы.
/// </summary>
public class RepairCircuitBoardCommand : IRequest
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="RepairCircuitBoardCommand" />.
	/// </summary>
	/// <param name="circuitBoardId">Идентификатор платы.</param>
	public RepairCircuitBoardCommand(Guid circuitBoardId) => CircuitBoardId = circuitBoardId;
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
