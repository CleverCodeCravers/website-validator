namespace WebsiteValidator.BL.Interfaces
{
    public interface IValidatedWebpage : IWebpage
    {
        IValidationMessage[] ValidationMessages { get; }
    }
}