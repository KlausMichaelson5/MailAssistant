namespace MailAssistant.WebApi.Models
{
    /// <summary>
    /// Represents a request for an email draft.
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Gets or sets the user's request for the email draft.
        /// </summary>
        public string UserRequest { get; set; } = string.Empty;
    }
}
