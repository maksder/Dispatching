using MediatR;

namespace Dispatching.Service.UseCase.SetQualityControlResult;

/// <summary>
/// Представляет команду установки результат контроля качества.
/// </summary>
public class SetQualityControlResultForCircuitBoardCommand : IRequest<bool>
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="SetQualityControlResultForCircuitBoardCommand" />.
	/// </summary>
	/// <param name="circuitBoardId">Идентификатор платы.</param>
	/// <param name="qualityControlResult">Результат контроля качества.</param>
	public SetQualityControlResultForCircuitBoardCommand(Guid circuitBoardId, bool qualityControlResult)
	{
		CircuitBoardId = circuitBoardId;
		QualityControlResult = qualityControlResult;
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

	/// <summary>
	/// Возвращает результат контроля качества.
	/// </summary>
	public bool QualityControlResult
	{
		get;
	}
	#endregion
}
