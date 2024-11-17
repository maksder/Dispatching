using Dispatching.Domain.CircuitBoards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dispatching.Dal.Persistence.CircuitBoards;

/// <summary>
/// Определяет конфигурацию сущности <see cref="CircuitBoard" />.
/// </summary>
public class CircuitBoardConfiguration : IEntityTypeConfiguration<CircuitBoard>
{
	#region IEntityTypeConfiguration<CircuitBoard> members
	/// <inheritdoc />
	public void Configure(EntityTypeBuilder<CircuitBoard> builder)
	{
		builder.ToTable("circuit_boards");
		builder.Property(p => p.Id)
			   .HasColumnName("id")
			   .ValueGeneratedNever();
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Name)
			   .HasColumnName("name");
		builder.Property(p => p.Status)
			   .HasColumnName("status")
			   .HasConversion<string>();
		builder.Property(p => p.QualityControlResult)
			   .HasColumnName("quality_control_result")
			   .HasConversion<string>();
		builder.Property(p => p.Name)
			   .HasColumnName("name");
		builder.OwnsMany(
			p =>
				p.Components, //Вероятно компонент может быть отдельной сущностью, применимой к разным платам и связь должна быть многие ко многим, но в задании об этом не написано, поэтому сделал так.
			navigationBuilder =>
			{
				navigationBuilder.ToTable("circuit_board_components");
				navigationBuilder.WithOwner()
								 .HasForeignKey("CircuitBoardId");
				navigationBuilder.Property<Guid>("CircuitBoardId")
								 .HasColumnName("circuit_board_id");
				navigationBuilder.Property(p => p.Id)
								 .HasColumnName("id")
								 .ValueGeneratedNever();
				navigationBuilder.HasKey(nameof(CircuitBoardComponent.Id), "CircuitBoardId");
				navigationBuilder.Property(p => p.Name)
								 .HasColumnName("name");
			});
	}
	#endregion
}
