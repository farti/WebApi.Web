namespace WebApi
{
    public interface IMinimalValidator
    {
        ValidationResult Validate<T>(T model);
    }
}