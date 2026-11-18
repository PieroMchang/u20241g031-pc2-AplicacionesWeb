namespace PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Value object representing an execution schedule interval with ScheduledFrom and ScheduledTo dates.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public record DateInterval
{
    /// <summary>
    /// Gets the start date of the schedule interval.
    /// </summary>
    public DateOnly ScheduledFrom { get; init; }

    /// <summary>
    /// Gets the end date of the schedule interval.
    /// </summary>
    public DateOnly ScheduledTo { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateInterval"/> record for EF Core materialization.
    /// </summary>
    protected DateInterval()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateInterval"/> record and validates its dates.
    /// </summary>
    /// <param name="scheduledFrom">The start date of the interval.</param>
    /// <param name="scheduledTo">The end date of the interval.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="scheduledTo"/> is less than or equal to <paramref name="scheduledFrom"/>.</exception>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public DateInterval(DateOnly scheduledFrom, DateOnly scheduledTo)
    {
        // Business Rule 5: If ScheduledTo is less than or equal to ScheduledFrom, throw ArgumentException.
        if (scheduledTo <= scheduledFrom)
        {
            throw new ArgumentException("ScheduledTo must be greater than ScheduledFrom in a DateInterval.", nameof(scheduledTo));
        }

        ScheduledFrom = scheduledFrom;
        ScheduledTo = scheduledTo;
    }

    /// <summary>
    /// Determines whether the schedule interval has elapsed relative to the specified reference date.
    /// </summary>
    /// <param name="referenceDate">The date to evaluate against <see cref="ScheduledTo"/>.</param>
    /// <returns><c>true</c> if <paramref name="referenceDate"/> is after <see cref="ScheduledTo"/>; otherwise, <c>false</c>.</returns>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public bool HasElapsed(DateOnly referenceDate)
    {
        // Business Rule 6: Returns true if referenceDate is after ScheduledTo.
        return referenceDate > ScheduledTo;
    }
}