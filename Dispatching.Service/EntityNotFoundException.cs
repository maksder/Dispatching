namespace Dispatching.Service;

/// <summary>
/// Представляет исключение в случае, если сущность не найдена.
/// </summary>
public class EntityNotFoundException : Exception
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр <see cref="EntityNotFoundException" />.
	/// </summary>
	/// <param name="EntityType"></param>
	/// <param name="EntityId"></param>
	public EntityNotFoundException(string EntityType, string EntityId) => ErrorMessage = $"Сущность типа {EntityType} с идентификатором {EntityId} не найдена.";
	#endregion

	#region Properties
	public string ErrorMessage
	{
		get;
	}
	#endregion
}
