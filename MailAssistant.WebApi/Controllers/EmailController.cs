using MailAssistant.Services.Interfaces;
using MailAssistant.WebApi.Interfaces;
using MailAssistant.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailAssistant.WebAPI.Controllers
{
    /// <summary>
    /// API controller for handling email-related requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailDataService _emailDataService;
        private readonly ILogger<EmailController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailController"/> class.
        /// </summary>
        /// <param name="emailDataService">The email data service.</param>
        /// <param name="logger">The Logger client to log errors and information.</param>
        public EmailController(IEmailDataService emailDataService, ILogger<EmailController> logger)
        {
            _emailDataService = emailDataService;
            _logger = logger;   
        }

        /// <summary>
        /// Gets a draft email based on the user's request.
        /// </summary>
        /// <param name="request">The email request containing the user's request.</param>
        /// <returns>An <see cref="IActionResult"/> containing the draft email.</returns>
        [HttpPost("GetDraftEmail")]
        public async Task<IActionResult> GetDraftEmail([FromBody] EmailRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserRequest))
            {
                _logger.LogWarning($"Invalid request.");
                return BadRequest("Invalid request.");
            }

            try
            {
                var response = await _emailDataService.GetDraftEmail(request.UserRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error:{ex.Message}");
                return StatusCode(500, $"Internal server error: Please try again later");
            }
        }
    }
}