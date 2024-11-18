using MediatR;

namespace Dispatching.Service.UseCase.Pack;

/// <summary>
/// Представляет команду упаковки платы.
/// </summary>
public class PackCircuitBoardCommand : IRequest<bool>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="PackCircuitBoardCommand" />.
	/// </summary>
	/// <param name="circuitBoardId">Идентификатор платы.</param>
	public PackCircuitBoardCommand(Guid circuitBoardId) => CircuitBoardId = circuitBoardId;
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
