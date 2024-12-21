using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters;

public class DateTimeUtcConverter() : ValueConverter<DateTime, DateTime>(
    x => x.ToUniversalTime(),
    y => y.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(y, DateTimeKind.Utc) : y.ToUniversalTime());
