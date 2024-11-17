namespace Dispatching.Domain.Common;

/// <summary>
/// Представляет интерфейс сущности
/// </summary>
public interface IEntity
{
	#region Properties
	/// <summary>
	/// Возвращает идентификатор сущности.
	/// </summary>
	Guid Id
	{
		get;
	}
	#endregion
}
