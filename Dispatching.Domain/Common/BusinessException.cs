namespace Dispatching.Domain.Common;

/// <summary>
/// Представляет исключение бизнес логики.
/// </summary>
public class BusinessException : Exception
{
	#region .ctor
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="BusinessException" />.
	/// </summary>
	/// <param name="errorMessage">Текст ошибки.</param>
	public BusinessException(string errorMessage) => ErrorMessage = errorMessage;
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает текст ошибки.
	/// </summary>
	public string ErrorMessage
	{
		get;
	}
	#endregion
}
