namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.ValueObjects;

/// <summary>
/// Value object representing the UUID (Guid) identifier of an affiliate store originating in another bounded context.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public record StoreIdentifier
{
    /// <summary>
    /// Gets the UUID (Guid) value of the affiliate store.
    /// </summary>
    public Guid Value { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StoreIdentifier"/> record with a GUID value.
    /// </summary>
    /// <param name="value">The UUID value.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public StoreIdentifier(Guid value)
    {
        // Business Rule 3: StoreIdentifier contains a Guid (UUID) Value identifying the affiliate store.
        if (value == Guid.Empty)
        {
            throw new ArgumentException("StoreIdentifier Value cannot be an empty Guid.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StoreIdentifier"/> record by parsing a UUID string.
    /// </summary>
    /// <param name="value">The string representation of the UUID.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a valid non-empty UUID.</exception>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public StoreIdentifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Guid.TryParse(value, out var parsedGuid) || parsedGuid == Guid.Empty)
        {
            throw new ArgumentException("StoreIdentifier must be a valid non-empty Guid (UUID) string.", nameof(value));
        }

        Value = parsedGuid;
    }
}