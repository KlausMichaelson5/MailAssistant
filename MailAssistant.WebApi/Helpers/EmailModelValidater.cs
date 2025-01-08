using MailAssistant.WebApi.Models;

namespace MailAssistant.WebApi.Helpers
{
    /// <summary>
    /// Provides validation methods for email model.
    /// </summary>
    public static class EmailModelValidator
    {
        /// <summary>
        /// Checks if any property of the given EmailModel is null or empty.
        /// </summary>
        /// <param name="emailModel">The EmailModel to validate.</param>
        /// <returns><c>true</c> if any property is null or empty; otherwise, <c>false</c>.</returns>
        public static bool ArePropertiesNullOrEmpty(EmailModel emailModel)
        {
            if (emailModel == null) return false;

            if (string.IsNullOrEmpty($"{emailModel}")) return false;

            return string.IsNullOrEmpty(emailModel.EmailSender) ||
                string.IsNullOrEmpty(emailModel.EmailRecipient) ||
                string.IsNullOrEmpty(emailModel.EmailSubject) ||
                string.IsNullOrEmpty(emailModel.EmailPurpose);
        }
    }
}
