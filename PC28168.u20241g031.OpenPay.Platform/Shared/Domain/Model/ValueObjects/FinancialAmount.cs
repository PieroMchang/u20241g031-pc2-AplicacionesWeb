namespace PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Value object representing a financial amount with a non-negative decimal amount and a currency code.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public record FinancialAmount
{
    /// <summary>
    /// Gets the monetary amount value.
    /// </summary>
    public decimal Amount { get; init; }

    /// <summary>
    /// Gets the currency code string.
    /// </summary>
    public string CurrencyCode { get; init; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="FinancialAmount"/> record for EF Core materialization.
    /// </summary>
    protected FinancialAmount()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FinancialAmount"/> record and validates amount and currency rules.
    /// </summary>
    /// <param name="amount">The decimal amount (must be greater than or equal to zero).</param>
    /// <param name="currencyCode">The currency code string (cannot be null, empty, or whitespace).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="amount"/> is less than <see cref="decimal.Zero"/>.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="currencyCode"/> is null, empty, or whitespace.</exception>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public FinancialAmount(decimal amount, string currencyCode)
    {
        // Business Rule 7: Amount must be >= decimal.Zero, otherwise throw ArgumentOutOfRangeException.
        if (amount < decimal.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, "FinancialAmount Amount must be greater than or equal to zero.");
        }

        // Business Rule 8: CurrencyCode must not be null, empty, or whitespace, otherwise throw ArgumentNullException.
        if (string.IsNullOrWhiteSpace(currencyCode))
        {
            throw new ArgumentNullException(nameof(currencyCode), "FinancialAmount CurrencyCode cannot be null, empty, or whitespace.");
        }

        Amount = amount;
        CurrencyCode = currencyCode.Trim();
    }

    /// <summary>
    /// Multiplies the financial amount by the specified factor while keeping the same currency code.
    /// </summary>
    /// <param name="factor">The multiplication factor.</param>
    /// <returns>A new <see cref="FinancialAmount"/> with the multiplied amount and identical currency code.</returns>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public FinancialAmount MultiplyBy(decimal factor)
    {
        // Business Rule 9: Apply a multiplier (MultiplyBy(decimal factor)) keeping the same CurrencyCode.
        return new FinancialAmount(Amount * factor, CurrencyCode);
    }
}