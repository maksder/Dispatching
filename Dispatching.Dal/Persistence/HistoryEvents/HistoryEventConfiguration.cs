using Dispatching.Domain.History;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dispatching.Dal.Persistence.HistoryEvents;

/// <summary>
/// Определяет конфигурацию сущности <see cref="HistoryEvent" />.
/// </summary>
public class HistoryEventConfiguration : IEntityTypeConfiguration<HistoryEvent>
{
	#region IEntityTypeConfiguration<HistoryEvent> members
	/// <inheritdoc />
	public void Configure(EntityTypeBuilder<HistoryEvent> builder)
	{
		builder.ToTable("history_events");
		builder.Property(p => p.Id)
			   .HasColumnName("id");
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Description)
			   .HasColumnName("description");
		builder.Property(p => p.CreatedDateTime)
			   .HasColumnName("created_date_time");
	}
	#endregion
}
