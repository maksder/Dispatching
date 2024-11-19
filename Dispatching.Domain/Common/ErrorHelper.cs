using Dispatching.Domain.CircuitBoards;

namespace Dispatching.Domain.Common;

/// <summary>
/// Представляет инструмент для формирования текстов ошибок.
/// </summary>
public class ErrorHelper
{
	#region Public
	/// <summary>
	/// Возвращает наименование статуса на для формирования текста ошибки.
	/// </summary>
	/// <param name="status"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public static string GetStatusNameForError(CircuitBoardStatus status)
	{
		return status switch
		{
			CircuitBoardStatus.Created => "создана",
			CircuitBoardStatus.InWorking => "в работе",
			CircuitBoardStatus.Packed => "упакована",
			CircuitBoardStatus.InQualityControl => "на контроле качества",
			CircuitBoardStatus.InRepair => "в ремонте",
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
		};
	}
	#endregion
}
