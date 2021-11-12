namespace WebsiteValidator.BL.Interfaces
{
    public interface IValidator
    {
        IValidationMessage[] Validate(IWebpage webpage);
    }
}