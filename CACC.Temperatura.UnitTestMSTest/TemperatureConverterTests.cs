using CACC.Temperatura;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CACC.Temperatura.UnitTestMSTest;

[TestClass]
public class TemperatureConverterTests
{
    private const double Delta = 0.0001;
    private TemperatureConverter _converter = null!;

    [TestInitialize]
    public void Setup() => _converter = new TemperatureConverter();

    // ---------- Casos positivos: Celsius -> Fahrenheit ----------

    [TestMethod]
    public void CelsiusToFahrenheit_ZeroCelsius_Returns32()
        => Assert.AreEqual(32.0, _converter.CelsiusToFahrenheit(0), Delta);

    [TestMethod]
    public void CelsiusToFahrenheit_BoilingPoint_Returns212()
        => Assert.AreEqual(212.0, _converter.CelsiusToFahrenheit(100), Delta);

    [TestMethod]
    public void CelsiusToFahrenheit_BodyTemperature_Returns98_6()
        => Assert.AreEqual(98.6, _converter.CelsiusToFahrenheit(37), Delta);

    [TestMethod]
    public void CelsiusToFahrenheit_NegativeValue_ReturnsCorrectValue()
        => Assert.AreEqual(14.0, _converter.CelsiusToFahrenheit(-10), Delta);

    [TestMethod]
    public void CelsiusToFahrenheit_MinusForty_ReturnsMinusForty()
        => Assert.AreEqual(-40.0, _converter.CelsiusToFahrenheit(-40), Delta);

    // ---------- Casos positivos: Fahrenheit -> Celsius ----------

    [TestMethod]
    public void FahrenheitToCelsius_32_ReturnsZero()
        => Assert.AreEqual(0.0, _converter.FahrenheitToCelsius(32), Delta);

    [TestMethod]
    public void FahrenheitToCelsius_212_Returns100()
        => Assert.AreEqual(100.0, _converter.FahrenheitToCelsius(212), Delta);

    [TestMethod]
    public void FahrenheitToCelsius_98_6_Returns37()
        => Assert.AreEqual(37.0, _converter.FahrenheitToCelsius(98.6), Delta);

    [TestMethod]
    public void FahrenheitToCelsius_NegativeValue_ReturnsCorrectValue()
        => Assert.AreEqual(-17.7778, _converter.FahrenheitToCelsius(0), Delta);

    [TestMethod]
    public void FahrenheitToCelsius_MinusForty_ReturnsMinusForty()
        => Assert.AreEqual(-40.0, _converter.FahrenheitToCelsius(-40), Delta);

    // ---------- Valores límite ----------

    [TestMethod]
    public void CelsiusToFahrenheit_AbsoluteZero_ReturnsAbsoluteZeroFahrenheit()
        => Assert.AreEqual(-459.67, _converter.CelsiusToFahrenheit(TemperatureConverter.AbsoluteZeroCelsius), Delta);

    [TestMethod]
    public void FahrenheitToCelsius_AbsoluteZero_ReturnsAbsoluteZeroCelsius()
        => Assert.AreEqual(-273.15, _converter.FahrenheitToCelsius(TemperatureConverter.AbsoluteZeroFahrenheit), Delta);

    [TestMethod]
    public void CelsiusToFahrenheit_VeryLargeValue_ReturnsCorrectValue()
        => Assert.AreEqual(1832.0, _converter.CelsiusToFahrenheit(1000), Delta);

    [TestMethod]
    public void RoundTrip_CelsiusToFahrenheitAndBack_ReturnsOriginalValue()
    {
        const double original = 25.5;
        var fahrenheit = _converter.CelsiusToFahrenheit(original);
        Assert.AreEqual(original, _converter.FahrenheitToCelsius(fahrenheit), Delta);
    }

    // ---------- Casos negativos ----------

    [TestMethod]
    public void CelsiusToFahrenheit_BelowAbsoluteZero_ThrowsArgumentOutOfRangeException()
        => Assert.ThrowsException<ArgumentOutOfRangeException>(() => _converter.CelsiusToFahrenheit(-273.16));

    [TestMethod]
    public void FahrenheitToCelsius_BelowAbsoluteZero_ThrowsArgumentOutOfRangeException()
        => Assert.ThrowsException<ArgumentOutOfRangeException>(() => _converter.FahrenheitToCelsius(-459.68));

    [TestMethod]
    public void CelsiusToFahrenheit_NaN_ThrowsArgumentOutOfRangeException()
        => Assert.ThrowsException<ArgumentOutOfRangeException>(() => _converter.CelsiusToFahrenheit(double.NaN));

    [TestMethod]
    public void FahrenheitToCelsius_NaN_ThrowsArgumentOutOfRangeException()
        => Assert.ThrowsException<ArgumentOutOfRangeException>(() => _converter.FahrenheitToCelsius(double.NaN));

    [TestMethod]
    public void CelsiusToFahrenheit_NegativeInfinity_ThrowsArgumentOutOfRangeException()
        => Assert.ThrowsException<ArgumentOutOfRangeException>(() => _converter.CelsiusToFahrenheit(double.NegativeInfinity));
}
