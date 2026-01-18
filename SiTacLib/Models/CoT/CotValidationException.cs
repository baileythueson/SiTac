namespace SiTacLib.Models.CoT;

public class CotValidationException : Exception
{
    public CotValidationException(string message) : base(message) { }

    public CotValidationException(string propertyName, string message) : base(
        $"Invalid CoT Data [{propertyName}]: {message}") { }
    
    public CotValidationException(string propertyName, string propertyValue, string message) : base(
        $"Invalid CoT Data [{propertyName}={propertyValue}]: {message}") { }
}