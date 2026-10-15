namespace CACC.StringManipulator;

/// <summary>
/// Operaciones de manipulación de cadenas de texto.
/// </summary>
public class StringManipulator
{
    /// <summary>
    /// Invierte el orden de los caracteres de la cadena.
    /// </summary>
    /// <exception cref="ArgumentNullException">Si <paramref name="input"/> es null.</exception>
    public string ReverseString(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    /// <summary>
    /// Elimina todos los espacios en blanco (espacios, tabulaciones, saltos de línea) de la cadena.
    /// </summary>
    /// <exception cref="ArgumentNullException">Si <paramref name="input"/> es null.</exception>
    public string RemoveSpaces(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
    }
}
