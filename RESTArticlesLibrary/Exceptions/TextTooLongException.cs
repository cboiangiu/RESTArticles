namespace RESTArticlesLibrary.Exceptions;

public class TextTooLongException : Exception
{
    public TextTooLongException(string field,int maxLength) : base($"{field} - Text too long! Maximum number of characters: {maxLength}") { }
}