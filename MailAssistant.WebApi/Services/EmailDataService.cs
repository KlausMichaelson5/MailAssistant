using MailAssistant.Services.Interfaces;
using MailAssistant.WebApi.Interfaces;

namespace MailAssistant.WebApi.Services
{

    /// <summary>
    /// Provides email data service extending <see cref="IEmailDataService"/>.
    /// </summary>
    internal class EmailDataService : IEmailDataService
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailDataService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailDataService"/> class.
        /// </summary>
        /// <param name="emailService">The email service.</param>
        /// <param name="logger">The Logger client to log errors and information.</param>
        public EmailDataService(IEmailService emailService, ILogger<EmailDataService> logger)
        {
            _emailService = emailService;
            _logger = logger;   
        }

        public async Task<string> GetDraftEmail(string userRequest)
        {

            var response = string.Empty;
            try
            {
                response = await _emailService.GetAssistantDraftEmail(userRequest);
            }
            catch (Exception ex)
            {
                response = "Internal server error.Please try again later.";
                _logger.LogError(ex.Message);
            }
            return response;
        }

    }
}