namespace CACC.Temperatura;

/// <summary>
/// Convierte temperaturas entre las escalas Celsius y Fahrenheit.
/// </summary>
public class TemperatureConverter
{
    /// <summary>Cero absoluto en grados Celsius.</summary>
    public const double AbsoluteZeroCelsius = -273.15;

    /// <summary>Cero absoluto en grados Fahrenheit.</summary>
    public const double AbsoluteZeroFahrenheit = -459.67;

    /// <summary>
    /// Convierte grados Celsius a Fahrenheit: F = C * 9/5 + 32.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Si el valor es NaN o está por debajo del cero absoluto.
    /// </exception>
    public double CelsiusToFahrenheit(double celsius)
    {
        if (double.IsNaN(celsius) || celsius < AbsoluteZeroCelsius)
        {
            throw new ArgumentOutOfRangeException(
                nameof(celsius), celsius,
                $"La temperatura no puede ser menor al cero absoluto ({AbsoluteZeroCelsius} °C).");
        }

        return celsius * 9.0 / 5.0 + 32.0;
    }

    /// <summary>
    /// Convierte grados Fahrenheit a Celsius: C = (F - 32) * 5/9.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Si el valor es NaN o está por debajo del cero absoluto.
    /// </exception>
    public double FahrenheitToCelsius(double fahrenheit)
    {
        if (double.IsNaN(fahrenheit) || fahrenheit < AbsoluteZeroFahrenheit)
        {
            throw new ArgumentOutOfRangeException(
                nameof(fahrenheit), fahrenheit,
                $"La temperatura no puede ser menor al cero absoluto ({AbsoluteZeroFahrenheit} °F).");
        }

        return (fahrenheit - 32.0) * 5.0 / 9.0;
    }
}
