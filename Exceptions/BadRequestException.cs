namespace LDKProject.Exceptions;

[Serializable]
public class BadRequestException : Exception
{
    public BadRequestException() : base() { }
    public BadRequestException(string message) : base(message) { }
    public BadRequestException(string message, Exception inner) : base(message, inner) { }
}
