using WebsiteValidator.BL.Enums;

namespace WebsiteValidator.BL.Interfaces
{
    public interface IValidationMessage
    {
        ValidationMessageSeverityEnum Severity { get; }
        string Message { get; }
    }
}