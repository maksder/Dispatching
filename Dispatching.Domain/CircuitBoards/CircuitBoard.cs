using Dispatching.Domain.Common;

namespace Dispatching.Domain.CircuitBoards;

/// <summary>
/// Представляет печатную плату.
/// </summary>
public class CircuitBoard : IEntity
{
	#region Data
	#region Fields
	private readonly List<CircuitBoardComponent> _components = new();
	#endregion
	#endregion

	#region .ctor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public CircuitBoard()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	{
	}

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CircuitBoard" />.
	/// </summary>
	/// <param name="id">Идентификатор.</param>
	/// <param name="name">Наименование.</param>
	public CircuitBoard(Guid id, string name)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name);
		Name = name;
		Status = CircuitBoardStatus.Created;
		Id = id;
	}
	#endregion

	#region Properties
	/// <summary>
	/// Возвращает наименование продукции.
	/// </summary>
	public string Name
	{
		get;
	}

	/// <summary>
	/// Возвращает результат контроля качества.
	/// </summary>
	public QualityControlResult? QualityControlResult
	{
		get;
		private set;
	}

	/// <summary>
	/// Возвращает статус продукции.
	/// </summary>
	public CircuitBoardStatus Status
	{
		get;
		private set;
	}
	/// <summary>
	/// Возвращает компоненты.
	/// </summary>
	public IReadOnlyCollection<CircuitBoardComponent> Components => _components;
	#endregion

	#region Public
	/// <summary>
	/// Добавляет компонент плате.
	/// </summary>
	/// <param name="component">Компонент.</param>
	/// <exception cref="BusinessException">Если плата в неподходящем статусе.</exception>
	public void AddComponent(CircuitBoardComponent component)
	{
		if (Status != CircuitBoardStatus.Created && Status != CircuitBoardStatus.InWorking)
		{
			throw new BusinessException($"Невозможно добавить компонент в в плату {Name}. Причина: плата {ErrorHelper.GetStatusNameForError(Status)}.");
		}

		if (Status == CircuitBoardStatus.Created)
		{
			Status = CircuitBoardStatus.InWorking;
		}

		_components.Add(component);
	}

	/// <summary>
	/// Производит контроль качества.
	/// </summary>
	/// <exception cref="BusinessException">Если плата в неподходящем статусе.</exception>
	public void MakeQualityControl()
	{
		if (Status != CircuitBoardStatus.InWorking && Status != CircuitBoardStatus.InRepair)
		{
			throw new BusinessException($"Невозможно произвести контроль качества для платы {Name}. Причина: плата {ErrorHelper.GetStatusNameForError(Status)}.");
		}

		Status = CircuitBoardStatus.InQualityControl;
	}

	/// <summary>
	/// Упаковывает продукцию.
	/// </summary>
	/// <exception cref="BusinessException">Если продукция в неподходящем статусе, либо результат контроля качества "Не годен."</exception>
	public void Pack()
	{
		if (Status != CircuitBoardStatus.InQualityControl && QualityControlResult != CircuitBoards.QualityControlResult.Good)
		{
			throw new BusinessException($"Невозможно упаковать плату {Name}. Причина: для платы не пройден контроль качества.");
		}
	}

	/// <summary>
	/// Производит ремонт платы.
	/// </summary>
	public void Repair()
	{
		if (Status != CircuitBoardStatus.InRepair)
		{
			throw new BusinessException($"Невозможно произвести ремонт платы {Name}. Причина: для платы не был произведен контроль качества.");
		}

		Status = CircuitBoardStatus.InQualityControl;
	}

	/// <summary>
	/// Устанавливает результат контрля качества.
	/// </summary>
	/// <param name="result">Результат.</param>
	public void SetQualityControlResult(bool result)
	{
		if (Status != CircuitBoardStatus.InQualityControl)
		{
			throw new BusinessException($"Невозможно установить результат контроля качества для платы {Name}. Причина: плата {ErrorHelper.GetStatusNameForError(Status)}.");
		}

		if (result)
		{
			QualityControlResult = CircuitBoards.QualityControlResult.Good;
			return;
		}

		QualityControlResult = CircuitBoards.QualityControlResult.NoGood;
		Status = CircuitBoardStatus.InRepair;
	}
	#endregion

	#region IEntity members
	/// <inheritdoc />
	public Guid Id
	{
		get;
	}
	#endregion
}
